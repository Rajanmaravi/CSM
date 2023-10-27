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
            _userBusiness = userBusiness??throw new ArgumentNullException(nameof(userBusiness));
            
            
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
        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            try
            {
                var creationStatus = await _userBusiness.AddUser(userModel);
                if (!string.IsNullOrEmpty(creationStatus))
                {
                    if (creationStatus.ToLower() != "success")
                        return BadRequest(creationStatus);

                    return Ok(creationStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in UserController.Create {ex}");
            }
            return BadRequest("The User could not be created with the given parameters. Please try again.");
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserModel userModel)
        {
            try
            {
                var updateStatus = await _userBusiness.UpdateUser(userModel);
                if (!string.IsNullOrEmpty(updateStatus))
                {
                    if (updateStatus.ToLower() != "success")
                        return BadRequest(updateStatus);

                    return Ok(updateStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in UserController.Update {ex}");
            }
            return BadRequest("The Technology could not be Update with the given parameters. Please try again.");
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string employeeCode)
        {
            try
            {
                var deleteStatus = await _userBusiness.DeleteUser(new UserModel {EmployeeCode=employeeCode });
                if (!string.IsNullOrEmpty(deleteStatus))
                {
                    if (deleteStatus.ToLower() != "success")
                        return BadRequest(deleteStatus);

                    return Ok(deleteStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in UserController.Delete {ex}");
            }
            return BadRequest("The User could not be Delete with the given parameters. Please try again.");
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(PasswordChangeModel passwordChangeModel)
        {
            try
            {
                var deleteStatus = await _userBusiness.ChangePassword(passwordChangeModel);
                if (!string.IsNullOrEmpty(deleteStatus))
                {
                    if (deleteStatus.ToLower() != "success")
                        return BadRequest(deleteStatus);

                    return Ok(deleteStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in UserController.ChangePassword {ex}");
            }
            return BadRequest("The password could not be changed. Please try again.");
        }
    }
}
