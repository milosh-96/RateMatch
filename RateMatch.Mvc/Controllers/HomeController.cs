using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RateMatch.Mvc.Data;
using RateMatch.Mvc.Models;
using RateMatch.Mvc.Models.Home;
using System.Diagnostics;

namespace RateMatch.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomePageViewModel viewModel = new HomePageViewModel()
            {
                Reviews = _context.MatchReviews
                .Include(x => x.Match)
                .Include(x => x.User)
                .OrderBy(x => x.CreatedAt).ToList()
            };
            viewModel.News = _context.ExternalContentLinks.OrderByDescending(x => x.CreatedAt).Take(10).ToList();
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}