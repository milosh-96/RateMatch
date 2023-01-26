using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RateMatch.Mvc.Data;
using RateMatch.Mvc.Data.IdentityEntities;
using RateMatch.Mvc.Models.SportsMatches;

namespace RateMatch.Mvc.Controllers
{
    public class MatchReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MatchReviewsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MatchReviewsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MatchReviewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MatchReviewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MatchReviewsController/Create
        [HttpPost]
        [Authorize]
        public IActionResult Create(int matchId,SportsMatchDetailsViewModel form)
        {
            var values = form.ReviewForm;
            values.UserId = Int32.Parse(_userManager.GetUserId(HttpContext.User));
            MatchReview review = new MatchReview();
            review.UserId = values.UserId;
            review.AuthorName = values.AuthorName;
            review.ReviewContent = values.ReviewContent.Trim();
            review.ReviewRating = values.ReviewRating;
            review.EditKey = Guid.NewGuid();
            review.MatchId = matchId;
            _context.MatchReviews.Add(review);
            _context.SaveChanges();
            return RedirectToAction("Details","SportsMatches",new
            {
                id=matchId
            });
        }

        // GET: MatchReviewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MatchReviewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MatchReviewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MatchReviewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
