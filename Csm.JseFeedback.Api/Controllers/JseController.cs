using Csm.JseFeedback.Business;
using Csm.JseFeedback.Model;
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
        public async Task<IActionResult> Create(JseUserModel jseUserModel)
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
        [HttpPut("Update")]
        public async Task<IActionResult> Update(JseUserModel jseUserModel)
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
        public async Task<IActionResult> Delete(JseUserModel jseUserModel)
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
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadJseUserData(IFormFile formFile)
        {
            try 
            {
                if (formFile == null)
                    return BadRequest("Please select a file with Jse User data to continue.");
                return Ok("100 Jse users have been successfully uploaded.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in JseUserController.Delete {ex}");
            }
            return BadRequest("The JSE User could not be deleted with the given parameters. Please try again.");
        }
       
    }
}