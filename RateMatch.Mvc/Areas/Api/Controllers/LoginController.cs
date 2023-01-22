using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace RateMatch.Mvc.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("{area}/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet("is-logged-in")]
        public IActionResult CheckLoginStatus()
        {
            var status = false;
            try
            {
                status = HttpContext.User.Identity.IsAuthenticated;
            }
            catch(Exception ex)
            {
                status = false;
            }
            return new JsonResult(status);
        }
    }
}
