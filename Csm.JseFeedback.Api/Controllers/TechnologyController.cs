using Csm.JseFeedback.Business;
using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Search;
using Csm.JseFeedback.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Csm.JseFeedback.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnologyController : BaseController
    {
        

        private readonly ITechnologyBusiness _technologyBusiness;

        public TechnologyController(ILogger<FeedbackController> logger, ITechnologyBusiness technologyBusiness) :base(logger)
        {
            _technologyBusiness = technologyBusiness;
            //_feedbackBusiness.AddFeedback
            ////_feedbackBusiness.UpdateFeedback
            ////_feedbackBusiness.DeleteFeedback
            ////_feedbackBusiness.SearchFeedbacks
            //_feedbackBusiness.GetFeedback
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(TechnologyModel technologyModel)
        {
            try
            {
                var creationStatus = await _technologyBusiness.AddTechnology(technologyModel);
                if(!string.IsNullOrEmpty(creationStatus))
                {
                    if (creationStatus.ToLower() != "success")
                        return BadRequest(creationStatus);

                    return Ok(creationStatus);
                }  
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception in ");
            }
            return BadRequest("The Technology could not be created with the given parameters. Please try again.");
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(TechnologyModel technologyModel)
        {
            try
            {
                var updateStatus = await _technologyBusiness.UpdateTechnology(technologyModel);
                if (!string.IsNullOrEmpty(updateStatus))
                {
                    if (updateStatus.ToLower() != "success")
                        return BadRequest(updateStatus);

                    return Ok(updateStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in ");
            }
            return BadRequest("The Technology could not be Update with the given parameters. Please try again.");
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string technologyCode)
        {
            try
            {
                var deleteStatus = await _technologyBusiness.DeleteTechnology(new TechnologyModel { TechnologyCode= technologyCode });
                if (!string.IsNullOrEmpty(deleteStatus))
                {
                    if (deleteStatus.ToLower() != "success")
                        return BadRequest(deleteStatus);

                    return Ok(deleteStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in ");
            }
            return BadRequest("The Technology could not be Update with the given parameters. Please try again.");
        }
        [HttpPost("Search")]
        public async Task<IActionResult> Search(TechnologySearchModel technologySearch)
        {
            try
            {
                var technologies = await _technologyBusiness.SearchTechnologies(technologySearch);
                return Ok(technologies);
               
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in ");
            }
            return BadRequest("Unable to fetch the list of Technologies.");

        }
        [HttpPost("Get")]
        public async Task<IActionResult> Get(TechnologySearchModel technologySearch)
        {
            try
            {
                var feedback = await _technologyBusiness.GetTechnology(technologySearch);
                return Ok(feedback);

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in ");
            }
            return BadRequest("Unable to fetch the requested Technology.");

        }
    }
}
