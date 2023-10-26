using Csm.JseFeedback.Business;
using Csm.JseFeedback.Commonlibrary;
using Csm.JseFeedback.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;

namespace Csm.JseFeedback.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IUserBusiness _userBusiness;

        public AuthController(ITokenService tokenService, IConfiguration configuration, IUserBusiness userBusiness)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _userBusiness = userBusiness ?? throw new ArgumentNullException(nameof(userBusiness));


        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] TokenRequest tokenRequest)
        {
            if (tokenRequest is null || string.IsNullOrEmpty(tokenRequest.UserName) || string.IsNullOrEmpty(tokenRequest.Password))
            {
                return BadRequest("Invalid client request");
            }
            var userDetails = await _userBusiness.ValidateUser(new LoginModel { EmployeeCode = tokenRequest.UserName, Password = tokenRequest.Password });

            if (userDetails == null)
                return Unauthorized();

            if (!tokenRequest.UserName.Equals(_configuration["Jwt:userName"].ParseToText()) || !tokenRequest.Password.Equals(_configuration["Jwt:password"].ParseToText()))
                return Unauthorized();

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userDetails.EmployeeCode)
            //,new Claim(ClaimTypes.Role, "Manager")
        };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            TokenResponse response = new TokenResponse
            {
                Token = accessToken,
                RefreshToken = refreshToken,
                DateOfExpiry = DateTime.Now.AddHours(_configuration["Jwt:TokenValidityInHours"].ParseInt()),
                RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration["Jwt:RefreshTokenValidityInDays"].ParseInt())
            };
            userDetails.RefreshToken = response.RefreshToken;
            userDetails.RefreshTokenExpiresOn = response.RefreshTokenExpiryTime;
            _userBusiness.UpdateRefreshToken(userDetails);
            return Ok(response);
        }
    }
}
