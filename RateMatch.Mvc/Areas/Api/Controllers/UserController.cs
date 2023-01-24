using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RateMatch.Mvc.Data.IdentityEntities;

namespace RateMatch.Mvc.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("{area}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("GetCurrent")]
        public async Task<IActionResult> GetCurrentLoggedInUser()
        {
            if(HttpContext.User.Identity != null)
            {
                if(HttpContext.User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    ApplicationUserDto dto = new ApplicationUserDto()
                    {
                        Id=user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber
                    };
                    return new JsonResult(dto);
                }
                return new JsonResult(false);
            }
            return new JsonResult(false);
        }

    }
}
