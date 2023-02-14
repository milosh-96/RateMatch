using Microsoft.AspNetCore.Mvc;

namespace RateMatch.Mvc.Areas.ControlArea.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
