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
    public class ReportingAuthorityController : BaseController
    {
        private readonly IReportingAuthorityBusiness _reportingAuthorityBusiness;
        public ReportingAuthorityController(ILogger<ReportingAuthorityController> logger, IReportingAuthorityBusiness reportingAuthorityBusiness) : base(logger)
        {
            _reportingAuthorityBusiness = reportingAuthorityBusiness ?? throw new ArgumentNullException(nameof(reportingAuthorityBusiness));

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(JseRaDaoModel jseRAModel)
        {
            try
            {
                var raStatus = await _reportingAuthorityBusiness.AddJseRa(jseRAModel);
                if (!string.IsNullOrEmpty(raStatus))
                {
                    if (raStatus.ToLower() != "success")
                        return BadRequest(raStatus);

                    return Ok(raStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in ReportingAuthorityController.Create {ex}");
            }
            return BadRequest("The JSE RA could not be created with the given parameters. Please try again.");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(JseRaDaoModel jseRAModel)
        {
            try
            {
                var updateStatus = await _reportingAuthorityBusiness.UpdateJseRa(jseRAModel);
                if (!string.IsNullOrEmpty(updateStatus))
                {
                    if (updateStatus.ToLower() != "success")
                        return BadRequest(updateStatus);

                    return Ok(updateStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in ReportingAuthorityController.Update {ex}");
            }
            return BadRequest("The Reporting Authority could not be updated with the given parameters. Please try again.");
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(JseRaDaoModel jseRAModel)
        {
            try
            {
                var deleteStatus = await _reportingAuthorityBusiness.DeleteReportingAuthority(jseRAModel);
                if (!string.IsNullOrEmpty(deleteStatus))
                {
                    if (deleteStatus.ToLower() != "success")
                        return BadRequest(deleteStatus);

                    return Ok(deleteStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in ReportingAuthorityController.Delete {ex}");
            }
            return BadRequest("The Reporting Authority could not be deleted with the given parameters. Please try again.");
        }

        [HttpGet("GetReportingAuthority")]
        public async Task<IActionResult> GetReportingAuthority()
        {
            try
            {
                var batchList = await _reportingAuthorityBusiness.GetJseRaDetails();
                return Ok(batchList);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in ReportingAuthorityController.GetReportingAuthority");
                return BadRequest("An error occurred while fetching the GetReportingAuthority list.");
            }
        }

        [HttpPost("MapRAIntern")]
        public async Task<IActionResult> MapRAIntern(JseUserRAMapModel jseRAMapModel)
        {
            try
            {
                var RaMapStatus = await _reportingAuthorityBusiness.CreateMapRAJse(jseRAMapModel);
                if (!string.IsNullOrEmpty(RaMapStatus))
                {
                    if (RaMapStatus.ToLower() != "success")
                        return BadRequest(RaMapStatus);

                    return Ok(RaMapStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in JseUserController.Create {ex}");
            }
            return BadRequest("The JSE User could not be created with the given parameters. Please try again.");
        }

        [HttpGet("GetMapRAIntern")]
        public async Task<IActionResult> GetMapRAWithIntern()
        {
            try
            {
                var batchList = await _reportingAuthorityBusiness.GetJseMapRaInternsDetails();
                return Ok(batchList);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in ReportingAuthorityController.GetJseMapRaInternsDetails");
                return BadRequest("An error occurred while fetching the GetJseMapRaInternsDetails list.");
            }
        }

        [HttpPost("MapRADelete")]
        public async Task<IActionResult> MapRADelete(JseUserRAMapDaoModel jseRAModel)
        {
            try
            {
                var deleteStatus = await _reportingAuthorityBusiness.DeleteMapRAIntern(jseRAModel);
                if (!string.IsNullOrEmpty(deleteStatus))
                {
                    if (deleteStatus.ToLower() != "success")
                        return BadRequest(deleteStatus);

                    return Ok(deleteStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Map ReportingAuthorityController.Delete {ex}");
            }
            return BadRequest("The Map Reporting Authority could not be deleted with the given parameters. Please try again.");
        }


        [HttpPost("MapRAUpdat")]
        public async Task<IActionResult> MapRAUpdate(JseUserRAMapDaoModel jseRAModel)
        {
            try
            {
                var updateStatus = await _reportingAuthorityBusiness.UpdateMapRAIntern(jseRAModel);
                if (!string.IsNullOrEmpty(updateStatus))
                {
                    if (updateStatus.ToLower() != "success")
                        return BadRequest(updateStatus);

                    return Ok(updateStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Map Intern with ReportingAuthorityController.Update {ex}");
            }
            return BadRequest("The Map Intern with Reporting Authority could not be Updated with the given parameters. Please try again.");
        }

    }
}
