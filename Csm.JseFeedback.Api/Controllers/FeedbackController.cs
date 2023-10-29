using Csm.JseFeedback.Business;
using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Search;
using Csm.JseFeedback.Model.Validator;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Csm.JseFeedback.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : BaseController
    {
        

        private readonly IFeedbackBusiness _feedbackBusiness;
        private readonly FeedbackDaoValidator _feedbackValidator;
        private readonly IFeedbackValidationService _feedbackValidationService;

        public FeedbackController(ILogger<FeedbackController> logger, IFeedbackBusiness feedbackBusiness, IFeedbackValidationService feedbackValidationService) :base(logger)
        {
            _feedbackBusiness = feedbackBusiness??throw new ArgumentNullException(nameof(feedbackBusiness));
            _feedbackValidationService = feedbackValidationService ?? throw new ArgumentNullException(nameof(feedbackValidationService)); 


        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(FeedbackDaoModel feedbackModel)
        {
            try
            {
                var validationStatus = _feedbackValidationService.ValidateDao(feedbackModel);
                if (!validationStatus.IsValid)
                    return BadRequest(validationStatus.Errors);
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
        public async Task<IActionResult> Update(FeedbackDaoModel feedbackModel)
        {
            try
            {
                var validationStatus = _feedbackValidationService.ValidateDao(feedbackModel);
                if (!validationStatus.IsValid)
                    return BadRequest(validationStatus.Errors);
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
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(FeedbackDaoModel feedbackModel)
        {
            try
            {
                var validationStatus = _feedbackValidationService.ValidateDao(feedbackModel);
                if (!validationStatus.IsValid)
                    return BadRequest(validationStatus.Errors);
                var deleteStatus = await _feedbackBusiness.DeleteFeedback(feedbackModel);
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
                var validationStatus = _feedbackValidationService.ValidateSearch(feedbackSearchModel);
                if (!validationStatus.IsValid)
                    return BadRequest(validationStatus.Errors);
                var feedbacks = await _feedbackBusiness.SearchFeedbacks(feedbackSearchModel);
                return Ok(feedbacks);
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in FeedbackController.Search {ex}");
            }
            return BadRequest("Unable to fetch the list of Feedbacks.");

        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var feedback = await _feedbackBusiness.GetFeedback(new FeedbackSearchModel { });
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
