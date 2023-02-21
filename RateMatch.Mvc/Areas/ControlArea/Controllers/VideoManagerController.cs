using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RateMatch.Mvc.Data;

namespace RateMatch.Mvc.Areas.ControlArea.Controllers
{
    [Area("ControlArea")]
    [Authorize("Editor")]
    public class VideoManagerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public VideoManagerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.VideoPosts.ToList());
        }
    }
}
