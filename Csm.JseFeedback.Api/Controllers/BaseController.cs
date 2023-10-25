using Csm.JseFeedback.Business;
using Csm.JseFeedback.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Csm.JseFeedback.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BaseController : ControllerBase
    {
        

        protected readonly ILogger<BaseController> _logger;
        
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;            
        }
      
        
    }
}
