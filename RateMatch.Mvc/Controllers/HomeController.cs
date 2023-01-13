using Microsoft.AspNetCore.Mvc;
using RateMatch.Mvc.Data;
using RateMatch.Mvc.Models;
using System.Diagnostics;

namespace RateMatch.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<SportsMatch> matches = new List<SportsMatch>(){
                new SportsMatch() {
                    Id = 1,
                    MatchName = "Inter - Parma",
                    MatchResult = "2:1 (after extra time)",
                    Sport = "Football",
                    Competition = "Coppa Italia",
                    PlayedAt = new DateTime(2023, 1, 11, 19, 45, 00),
                    Reviews = new List<MatchReview>(){
                        new MatchReview(){
                            Id = 1,
                            ReviewContent = "This was very good match! Thank god Inter won!",
                            ReviewRating = 4,
                            UserId = 1
                        }
                    },
                },
                new SportsMatch() {
                    Id = 1,
                    MatchName = "Necaxa - Atletico de San Luis",
                    MatchResult = "2:3",
                    Sport = "Football",
                    Competition = "Liga MX",
                    PlayedAt = new DateTime(2023, 1, 11, 19, 45, 00),
                    Reviews = new List<MatchReview>(){
                        new MatchReview(){
                            Id = 1,
                            ReviewContent = "Fun match but awful Nexaxa defending!!",
                            ReviewRating = 5,
                            UserId = 1
                        }
                    }
                },
                new SportsMatch(){
                    Id = 1,
                    MatchName = "Torino - Milan",
                    MatchResult = "0:1",
                    Sport = "Football",
                    Competition = "Coppa Italia",
                    PlayedAt = new DateTime(2023, 1, 12, 19, 45, 00),
                    Reviews = new List<MatchReview>(){
                        new MatchReview(){
                            Id = 1,
                            ReviewContent = "LOL Milan! Torino are through!",
                            ReviewRating = 5,
                            UserId = 1
                        }
                    }
                }
            };
            return View(matches);
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