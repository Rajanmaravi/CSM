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
        private readonly ILogger<AuthController> _logger;

        public AuthController(ITokenService tokenService, IConfiguration configuration, IUserBusiness userBusiness,ILogger<AuthController> logger)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _userBusiness = userBusiness ?? throw new ArgumentNullException(nameof(userBusiness));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] TokenRequest tokenRequest)
        {
            try
            {
                if (tokenRequest is null || string.IsNullOrEmpty(tokenRequest.UserName) || string.IsNullOrEmpty(tokenRequest.Password))
                {
                    return BadRequest("Unable to generate access token.Invalid client request.");
                }
                var userDetails = await _userBusiness.ValidateUser(new LoginModel { EmployeeCode = tokenRequest.UserName, Password = tokenRequest.Password });

                if (userDetails == null)
                    return BadRequest("Unable to generate access token.Invalid credentials!");

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
                await _userBusiness.UpdateRefreshToken(new UserDaoModel
                {
                    EmployeeCode = userDetails.EmployeeCode,
                    RefreshToken = userDetails.RefreshToken,
                    RefreshTokenExpiresOn = userDetails.RefreshTokenExpiresOn

                }
           );
                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception while generating access token. {ex}");
            }
            return BadRequest("Unable to generate access token.");

        }

        [HttpPost, Route("RefreshToken")]
        public async Task<IActionResult> Refresh(TokenApiModel tokenApiModel)
        {
            if (tokenApiModel is null)
                return BadRequest("Invalid client request");

            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default

            var users = await _userBusiness.SearchUser(new UserSearchModel { EmployeeCode = username });
            if (users == null || users.Count() <= 0)
                return BadRequest("Invalid client request");
            var loggedInUser = users.FirstOrDefault();

            TokenResponse response = new TokenResponse
            {
                Token = _tokenService.GenerateAccessToken(principal.Claims),
                RefreshToken = _tokenService.GenerateRefreshToken(),
                DateOfExpiry = DateTime.Now.AddHours(_configuration["Jwt:TokenValidityInHours"].ParseInt()),
                RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration["Jwt:RefreshTokenValidityInDays"].ParseInt())
            };
            loggedInUser.RefreshToken = response.RefreshToken;
            loggedInUser.RefreshTokenExpiresOn = response.RefreshTokenExpiryTime;
            await _userBusiness.UpdateRefreshToken(new UserDaoModel 
                {
                EmployeeCode=loggedInUser.EmployeeCode,RefreshToken=loggedInUser.RefreshToken,RefreshTokenExpiresOn=loggedInUser.RefreshTokenExpiresOn
                
            }
            );

            return Ok(response);
        }

        [HttpPost, Authorize]
        [Route("Revoke")]
        public async Task<IActionResult> Revoke()
        {
            var username = User.Identity.Name;

            var users = await _userBusiness.SearchUser(new UserSearchModel { EmployeeCode = username });
            if (users == null || users.Count() <= 0)
                return BadRequest("Invalid client request");
            var loggedInUser = users.FirstOrDefault();
            loggedInUser.RefreshToken = null;
            loggedInUser.RefreshTokenExpiresOn = null;
            await _userBusiness.UpdateRefreshToken(new UserDaoModel
            {
                EmployeeCode = loggedInUser.EmployeeCode,
                RefreshToken = loggedInUser.RefreshToken,
                RefreshTokenExpiresOn = loggedInUser.RefreshTokenExpiresOn

            }
                       );
            return NoContent();
        }
    }
}
