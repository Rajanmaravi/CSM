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
    public class RoleController : BaseController
    {
        

        private readonly IRoleBusiness _roleBusiness;

        public RoleController(ILogger<RoleController> logger, IRoleBusiness roleBusiness) :base(logger)
        {
            _roleBusiness = roleBusiness??throw new ArgumentNullException(nameof(roleBusiness));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(RoleModel roleModel)
        {
            try
            {
                var creationStatus = await _roleBusiness.AddRole(roleModel);
                if(!string.IsNullOrEmpty(creationStatus))
                {
                    if (creationStatus.ToLower() != "success")
                        return BadRequest(creationStatus);

                    return Ok(creationStatus);
                }  
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception in RoleController.Create {ex}");
            }
            return BadRequest("The Role could not be created with the given parameters. Please try again.");
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(RoleModel roleModel)
        {
            try
            {
                var updateStatus = await _roleBusiness.UpdateRole(roleModel);
                if (!string.IsNullOrEmpty(updateStatus))
                {
                    if (updateStatus.ToLower() != "success")
                        return BadRequest(updateStatus);

                    return Ok(updateStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in RoleController.Update {ex}");
            }
            return BadRequest("The Role could not be Update with the given parameters. Please try again.");
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string roleCode)
        {
            try
            {
                var deleteStatus = await _roleBusiness.DeleteRole(new RoleModel {RoleCode=roleCode });
                if (!string.IsNullOrEmpty(deleteStatus))
                {
                    if (deleteStatus.ToLower() != "success")
                        return BadRequest(deleteStatus);

                    return Ok(deleteStatus);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in RoleController.Delete {ex}");
            }
            return BadRequest("The Role could not be Update with the given parameters. Please try again.");
        }
        [HttpPost("Search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                var technologies = await _roleBusiness.SearchRoles();
                return Ok(technologies);
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in RoleController.Search {ex}");
            }
            return BadRequest("Unable to fetch the list of Technologies.");

        }
       
    }
}
