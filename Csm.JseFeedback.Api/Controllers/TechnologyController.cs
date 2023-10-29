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
            _technologyBusiness = technologyBusiness??throw new ArgumentNullException(nameof(technologyBusiness));
           
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(TechnologyDaoModel technologyModel)
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
                _logger.LogError($"Exception in TechnologyController.Create {ex}");
            }
            return BadRequest("The Technology could not be created with the given parameters. Please try again.");
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(TechnologyDaoModel technologyModel)
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
                _logger.LogError($"Exception in TechnologyController.Update {ex}");
            }
            return BadRequest("The Technology could not be Update with the given parameters. Please try again.");
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(TechnologyDaoModel technologyModel)
        {
            try
            {
                var deleteStatus = await _technologyBusiness.DeleteTechnology(technologyModel);
                if (!string.IsNullOrEmpty(deleteStatus))
                {
                    if (deleteStatus.ToLower() != "success")
                        return BadRequest(deleteStatus);

                    return Ok(deleteStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in TechnologyController.Delete {ex}");
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
                _logger.LogError($"Exception in TechnologyController.Search {ex}");
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
                _logger.LogError($"Exception in TechnologyController.Get {ex}");
            }
            return BadRequest("Unable to fetch the requested Technology.");

        }
    }
}
