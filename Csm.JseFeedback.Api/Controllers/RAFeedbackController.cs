using Csm.JseFeedback.Business;
using Csm.JseFeedback.Business.Contract;
using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Csm.JseFeedback.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RAFeedbackController : BaseController
    {
        private readonly IReportingAuthorityFeedbackBusiness _rafeedbackBusiness;
        public RAFeedbackController(ILogger<BaseController> logger, IReportingAuthorityFeedbackBusiness rafeedbackBusiness) : base(logger)
        {
            _rafeedbackBusiness = rafeedbackBusiness ?? throw new ArgumentNullException(nameof(rafeedbackBusiness));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(RAFeedbackModel feedbackModel)
        {
            try
            {
                var creationFeedback = await _rafeedbackBusiness.AddRAFeedback(feedbackModel);
                if (!string.IsNullOrEmpty(creationFeedback))
                {
                    if (creationFeedback.ToLower() != "success")
                        return BadRequest(creationFeedback);

                    return Ok(creationFeedback);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in RAFeedbackController.Create {ex}");
            }
            return BadRequest("The feedback could not be created with the given parameters. Please try again.");
        }
        

        [HttpPost("GetRAFeedback")]
        public async Task<IActionResult> GetRAFeedback(FeedbackByRaCodeDaoModel feedback)
        {
            try
            {
                var creationFeedback = await _rafeedbackBusiness.GetRAFeedback(feedback);
                if (creationFeedback!= null)
                {
                    return Ok(creationFeedback);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in RAFeedbackController.Create {ex}");
            }
            return BadRequest("The feedback could not be created with the given parameters. Please try again.");
        }

        [HttpGet("GetFeedbackByRaCode/{raCode}")]
        public async Task<IActionResult> GetFeedbackRaCode(string raCode)
        {
            try
            {
                var getFeedback = await _rafeedbackBusiness.GetFeedbackByRaCode(raCode);
                if (getFeedback != null)
                {
                    return Ok(getFeedback);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in RAFeedbackController.Create {ex}");
            }
            return BadRequest("The feedback could not be created with the given parameters. Please try again.");
        }
    }
}
