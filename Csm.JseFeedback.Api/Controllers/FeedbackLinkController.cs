using Csm.JseFeedback.Business;
using Csm.JseFeedback.Business.Contract;
using Csm.JseFeedback.Business.Implementation;
using Csm.JseFeedback.Model.Dao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Csm.JseFeedback.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackLinkController : BaseController
    {
        private readonly IFeedbackLinkBusiness _feedbackLinkBusiness; 
        public FeedbackLinkController(ILogger<JseUserController> logger, IFeedbackLinkBusiness feedbackLinkBusiness) : base(logger)
        {
            _feedbackLinkBusiness = feedbackLinkBusiness ?? throw new ArgumentNullException(nameof(feedbackLinkBusiness));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(List<FeedbackLinkDaoModel> jseLinkModel)
        {
            try
            {
                var sendLinkStatus = await _feedbackLinkBusiness.SendLinkToRA(jseLinkModel);
                if (!string.IsNullOrEmpty(sendLinkStatus))
                {
                    if (sendLinkStatus.ToLower() != "success")
                        return BadRequest(sendLinkStatus);

                    return Ok(sendLinkStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in FeedbackLinkController.Create {ex}");
            }
            return BadRequest("The Feedback Link could not be created with the given parameters. Please try again.");
        }
    }
}
