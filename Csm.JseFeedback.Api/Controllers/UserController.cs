using Csm.JseFeedback.Business;
using Csm.JseFeedback.Model;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Csm.JseFeedback.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        

        private readonly IUserBusiness _userBusiness;

        public UserController(ILogger<UserController> logger, IUserBusiness userBusiness):base(logger)
        {
            _userBusiness = userBusiness;
        }
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(LoginModel loginModel)
        {
            try
            {
                if ((loginModel == null) || ((string.IsNullOrEmpty(loginModel.EmployeeCode) || string.IsNullOrEmpty(loginModel.Password))) )
                    return BadRequest("Please provide the credentials");
                var validationResult = _userBusiness.ValidateUser(loginModel);
                if (validationResult == null)
                    return BadRequest("The User was not authenticated.Either Employee Code or Password are incorrect.");
                return Ok(validationResult);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Exception in Validate User Controller");
                return BadRequest($"The User was not authenticated. Please try again.");
            }
        }
        
    }
}
