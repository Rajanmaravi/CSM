using Csm.JseFeedback.Business;
using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using Csm.JseFeedback.Model.Search;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Csm.JseFeedback.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JseUserController : BaseController
    {
        

        private readonly IJseUserBusiness _jseUserBusiness;

        public JseUserController(ILogger<JseUserController> logger, IJseUserBusiness jseUserBusiness) :base(logger)
        {
            _jseUserBusiness = jseUserBusiness ?? throw new ArgumentNullException(nameof(jseUserBusiness));
           
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(JseUserAddDaoModel jseUserModel)
        {
            try
            {
                var creationStatus = await _jseUserBusiness.AddJse(jseUserModel);
                if(!string.IsNullOrEmpty(creationStatus))
                {
                    if (creationStatus.ToLower() != "success")
                        return BadRequest(creationStatus);

                    return Ok(creationStatus);
                }  
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception in JseUserController.Create {ex}");
            }
            return BadRequest("The JSE User could not be created with the given parameters. Please try again.");
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(JseUserDaoModel jseUserModel)
        {
            try
            {
                var creationStatus = await _jseUserBusiness.UpdateJse(jseUserModel);
                if (!string.IsNullOrEmpty(creationStatus))
                {
                    if (creationStatus.ToLower() != "success")
                        return BadRequest(creationStatus);

                    return Ok(creationStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in JseUserController.Update {ex}");
            }
            return BadRequest("The JSE User could not be updated with the given parameters. Please try again.");
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(JseUserDaoModel jseUserModel)
        {
            try
            {
                var deleteStatus = await _jseUserBusiness.DeleteJse(jseUserModel);
                if (!string.IsNullOrEmpty(deleteStatus))
                {
                    if (deleteStatus.ToLower() != "success")
                        return BadRequest(deleteStatus);

                    return Ok(deleteStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in JseUserController.Delete {ex}");
            }
            return BadRequest("The JSE User could not be deleted with the given parameters. Please try again.");
        }
        [HttpPost("UploadJseUser")]
        public async Task<IActionResult> UploadJseUserData(IFormFile formFile)
        {
            try 
            {
                if (formFile == null)
                    return BadRequest("Please select a file with Jse User data to continue.");
                var uploadStatus = await _jseUserBusiness.UploadJseData(formFile);
             
                if (!string.IsNullOrEmpty(uploadStatus))
                {
                    var responseObject = new { status = uploadStatus };

                    if (uploadStatus.ToLower() != "success")
                        return BadRequest(responseObject);

                    return Ok(responseObject);
                }

                // Return an appropriate success response
                var successResponse = new { status = "success", message = "Jse users have been successfully uploaded." };
                return Ok(successResponse);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in JseUserController.Delete {ex}");
            }
            return BadRequest("The JSE User could not be deleted with the given parameters. Please try again.");
        }

        [HttpGet("GetJseUser")]
        public async Task<IActionResult> GetJseUser()
        {
            try
            {
                var jseList = await _jseUserBusiness.GetJseUserDetails();
                return Ok(jseList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in JseUserController.GetJseUserDetails");
                return BadRequest("An error occurred while fetching the JseUserDetails list.");
            }
        }

        [HttpGet("GetMapRAInterns")]
        public async Task<IActionResult> GetMapRAJseUser()
        {
            try
            {
                var jseList = await _jseUserBusiness.GetMapRAJseUserDetails();
                return Ok(jseList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in JseUserController.GetMapRAJseUser");
                return BadRequest("An error occurred while fetching the GetMapRAJseUser list.");
            }
        }       

    }
}
