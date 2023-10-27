using Csm.JseFeedback.Business;
using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Search;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Csm.JseFeedback.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : BaseController
    {
        

        private readonly IFeedbackBusiness _feedbackBusiness;

        public FeedbackController(ILogger<FeedbackController> logger, IFeedbackBusiness feedbackBusiness):base(logger)
        {
            _feedbackBusiness = feedbackBusiness??throw new ArgumentNullException(nameof(feedbackBusiness));
           
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(FeedbackModel feedbackModel)
        {
            try
            {
                var creationStatus = await _feedbackBusiness.AddFeedback(feedbackModel);
                if(!string.IsNullOrEmpty(creationStatus))
                {
                    if (creationStatus.ToLower() != "success")
                        return BadRequest(creationStatus);

                    return Ok(creationStatus);
                }  
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception in FeedbackController.Create {ex}");
            }
            return BadRequest("The feedback could not be created with the given parameters. Please try again.");
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(FeedbackModel feedbackModel)
        {
            try
            {
                var updateStatus = await _feedbackBusiness.UpdateFeedback(feedbackModel);
                if (!string.IsNullOrEmpty(updateStatus))
                {
                    if (updateStatus.ToLower() != "success")
                        return BadRequest(updateStatus);

                    return Ok(updateStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in FeedbackController.Update {ex}");
            }
            return BadRequest("The feedback could not be Update with the given parameters. Please try again.");
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string feedbackCode)
        {
            try
            {
                var deleteStatus = await _feedbackBusiness.DeleteFeedback(new FeedbackModel { FeedbackCode=feedbackCode});
                if (!string.IsNullOrEmpty(deleteStatus))
                {
                    if (deleteStatus.ToLower() != "success")
                        return BadRequest(deleteStatus);

                    return Ok(deleteStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in FeedbackController.Delete {ex}");
            }
            return BadRequest("The feedback could not be Update with the given parameters. Please try again.");
        }
        [HttpPost("Search")]
        public async Task<IActionResult> Search(FeedbackSearchModel feedbackSearchModel)
        {
            try
            {
                var feedbacks = await _feedbackBusiness.SearchFeedbacks(feedbackSearchModel);
                return Ok(feedbacks);
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in FeedbackController.Search {ex}");
            }
            return BadRequest("Unable to fetch the list of Feedbacks.");

        }
        [HttpPost("Get")]
        public async Task<IActionResult> Get(FeedbackSearchModel feedbackSearchModel)
        {
            try
            {
                var feedback = await _feedbackBusiness.GetFeedback(feedbackSearchModel);
                return Ok(feedback);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in FeedbackController.Get {ex}");
            }
            return BadRequest("Unable to fetch the requested feedback.");

        }
    }
}
