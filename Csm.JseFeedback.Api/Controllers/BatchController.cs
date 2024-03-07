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
    public class BatchController : BaseController
    {
        

        private readonly IBatchBusiness _batchBusiness;
        
        public BatchController(ILogger<BatchController> logger, IBatchBusiness batchBusiness) :base(logger)
        {
            _batchBusiness = batchBusiness ?? throw new ArgumentNullException(nameof(batchBusiness));


        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(BatchDaoModel batchDaoModel)
        {
            try
            {
                //var validationStatus = _feedbackValidationService.ValidateDao(feedbackModel);
                //if (!validationStatus.IsValid)
                //    return BadRequest(validationStatus.Errors);
                var creationStatus = await _batchBusiness.AddBatch(batchDaoModel);
                if(!string.IsNullOrEmpty(creationStatus))
                {
                    if (creationStatus.ToLower() != "success")
                        return BadRequest(creationStatus);

                    return Ok(creationStatus);
                }  
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception in BatchController.Create {ex}");
            }
            return BadRequest("The Batch could not be created with the given parameters. Please try again.");
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(BatchDaoModel batchDaoModel)
        {
            try
            {
                //var validationStatus = _feedbackValidationService.ValidateDao(feedbackModel);
                //if (!validationStatus.IsValid)
                //    return BadRequest(validationStatus.Errors);
                var updateStatus = await _batchBusiness.UpdateBatch(batchDaoModel);
                if (!string.IsNullOrEmpty(updateStatus))
                {
                    if (updateStatus.ToLower() != "success")
                        return BadRequest(updateStatus);

                    return Ok(updateStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in BatchController.Update {ex}");
            }
            return BadRequest("The Batch could not be Update with the given parameters. Please try again.");
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(BatchDaoModel batchDaoModel)
        {
            try
            {
                //var validationStatus = _feedbackValidationService.ValidateDao(feedbackModel);
                //if (!validationStatus.IsValid)
                //    return BadRequest(validationStatus.Errors);
                var deleteStatus = await _batchBusiness.DeleteBatch(batchDaoModel);
                if (!string.IsNullOrEmpty(deleteStatus))
                {
                    if (deleteStatus.ToLower() != "success")
                        return BadRequest(deleteStatus);

                    return Ok(deleteStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in BatchController.Delete {ex}");
            }
            return BadRequest("The batch could not be Update with the given parameters. Please try again.");
        }
        [HttpPost("Search")]
        public async Task<IActionResult> Search(BatchSearchModel batchSearchModel)
        {
            try
            {
                //var validationStatus = _feedbackValidationService.ValidateSearch(feedbackSearchModel);
                //if (!validationStatus.IsValid)
                //    return BadRequest(validationStatus.Errors);
                var feedbacks = await _batchBusiness.SearchBatches(batchSearchModel);
                return Ok(feedbacks);
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in BatchController.Search {ex}");
            }
            return BadRequest("Unable to fetch the list of Feedbacks.");

        }
        [HttpPost()]
        public async Task<IActionResult> GetBatch(BatchSearchModel batchSearchModel)
        {
            try
            {
                var feedback = await _batchBusiness.GetBatch(batchSearchModel);
                return Ok(feedback);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in BatchController.Get {ex}");
            }
            return BadRequest("Unable to fetch the requested Batch.");

        }

        [HttpGet("GetBatchList")]
        public async Task<IActionResult> GetBatchList()
        {
            try
            {
                var batchList = await _batchBusiness.GetBatchList();
                return Ok(batchList);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in BatchController.GetBatchList");
                return BadRequest("An error occurred while fetching the batch list.");
            }
        }

        [HttpGet("GetRA")]
        public async Task<IActionResult> GetRA()
        {
            try
            {
                var batchList = await _batchBusiness.GetRa();
                return Ok(batchList);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in BatchController.GetRa");
                return BadRequest("An error occurred while fetching the Ra list.");
            }
        }
    }
}
