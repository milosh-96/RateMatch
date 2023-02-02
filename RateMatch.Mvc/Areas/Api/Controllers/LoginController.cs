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
            if(HttpContext.User != null && HttpContext.User.Identity != null) 
            {
                status = HttpContext.User.Identity.IsAuthenticated;
            }
            return new JsonResult(status);
        }
      
    }
}
