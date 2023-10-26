using Csm.JseFeedback.Business;
using Csm.JseFeedback.Commonlibrary;
using Csm.JseFeedback.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Csm.JseFeedback.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public TokenController(IUserBusiness userBusiness, ITokenService tokenService,IConfiguration configuration)
        {
            this._userBusiness = userBusiness ?? throw new ArgumentNullException(nameof(userBusiness));
            this._tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(TokenApiModel tokenApiModel)
        {
            if (tokenApiModel is null)
                return BadRequest("Invalid client request");

            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default

            var users = await _userBusiness.SearchUser(new UserSearchModel {EmployeeCode=username });
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
            await _userBusiness.UpdateRefreshToken(loggedInUser);

            return Ok(response);
        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public async Task<IActionResult> Revoke()
        {
            var username = User.Identity.Name;

            var users = await _userBusiness.SearchUser(new UserSearchModel { EmployeeCode = username });
            if (users == null || users.Count() <= 0)
                return BadRequest("Invalid client request");
            var loggedInUser = users.FirstOrDefault();
            loggedInUser.RefreshToken = null;
            loggedInUser.RefreshTokenExpiresOn = null;
            _userBusiness.UpdateRefreshToken(loggedInUser);

            return NoContent();
        }
    }
}
