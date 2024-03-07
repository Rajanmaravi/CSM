using Microsoft.AspNetCore.Mvc;

namespace Csm.JseFeedback.Application.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
