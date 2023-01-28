using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RateMatch.Mvc.Data;
using RateMatch.Mvc.Data.IdentityEntities;
using RateMatch.Mvc.Models.MatchReviews;
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
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(int matchId, SportsMatchDetailsViewModel form)
        {
            var values = form.ReviewForm;
            MatchReview review = new MatchReview();
            review.UserId = _userManager.GetUserAsync(User).Result.Id;
            review.AuthorName = values.AuthorName;
            review.ReviewContent = values.ReviewContent.Trim();
            review.ReviewRating = values.ReviewRating;
            review.EditKey = Guid.NewGuid();
            review.MatchId = matchId;
            _context.MatchReviews.Add(review);
            _context.SaveChanges();
            return RedirectToAction("Details", "SportsMatches", new
            {
                id = matchId
            });
        }

        // GET: MatchReviewsController/Edit/5
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Edit Review";
            MatchReview? review = await _context.MatchReviews.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (review != null)
            {
                ApplicationUser? currentUser = await _userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    if (review.UserId == currentUser.Id)
                    {

                        MatchReviewEditViewModel viewModel = new MatchReviewEditViewModel()
                        {
                            Item = review
                        };
                        List<RatingChoice> choices = new List<RatingChoice>()
                        {
                            new RatingChoice(1,"Awful Match!"),
                            new RatingChoice(2,"Bad..."),
                            new RatingChoice(3,"Nothing special."),
                            new RatingChoice(4,"Good one!"),
                            new RatingChoice(5,"This was a true classic!")
                        };
                        viewModel.RatingChoices = new SelectList(choices, "Value", "", review.ReviewRating);

                        return View(viewModel);
                    }
                }
                //not authorized
                return new BadRequestResult();
            }
            return new NotFoundResult();
        }

        // POST: MatchReviewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(Prefix = "Item")] MatchReviewDto form)
        {
            MatchReview? review = await _context.MatchReviews.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (review != null)
            {
                ApplicationUser? currentUser = await _userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    if (review.UserId == currentUser.Id)
                    {
                        try
                        {
                            review.ReviewRating = form.ReviewRating;
                            if (form.ReviewContent == null)
                            {
                                form.ReviewContent = "";
                            }
                            review.ReviewContent = form.ReviewContent;
                            review.UpdatedAt = DateTime.UtcNow;
                            await _context.SaveChangesAsync();
                        }
                        catch(Exception e)
                        {
                            TempData["Error"] = e.Message;
                            return RedirectToAction("Edit", new { id = review.Id });
                        }
                        return RedirectToAction("Details", "SportsMatches", new { id = review.MatchId },"review-"+review.Id);
                    }
                }
                //not authorized
                return new BadRequestResult();
            }
            return new NotFoundResult();
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
