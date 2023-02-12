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
            // redirect to latest action for now //
            return RedirectToAction(nameof(IndexOfLatest));
            ViewData["Title"] = "Latest Reviews";
            LatestReviewsViewModel viewModel = new LatestReviewsViewModel();
            viewModel.Items = _context.MatchReviews.Include(x=>x.User).Include(x=>x.Match)
                .OrderByDescending(x => x.CreatedAt).ToList();
            return View(viewModel);
        }
        [HttpGet("/latest-reviews")]
        public ActionResult IndexOfLatest()
        {
            ViewData["Title"] = "Latest Reviews";
            LatestReviewsViewModel viewModel = new LatestReviewsViewModel();
            viewModel.Items = _context.MatchReviews.Include(x=>x.User).Include(x=>x.Match)
                .OrderByDescending(x => x.CreatedAt).ToList();
            return View("Index",viewModel);
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
        {   var user = _userManager.GetUserAsync(User).Result;
            if (!_context.MatchReviews.Any(x => x.MatchId == matchId && x.UserId == user.Id))
            {
                if (ModelState.IsValid)
                {

                    var values = form.ReviewForm;
                    MatchReview review = new MatchReview();
                    review.UserId = user.Id;
                    review.AuthorName = values.AuthorName;
                    if (values.ReviewContent != null)
                    {
                        review.ReviewContent = values.ReviewContent.Trim();
                    }
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
            }
            TempData["Error"] = "Review couldn't be added.";
            return RedirectToAction("Details", "SportsMatches", new { id = matchId });
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
                TempData["Error"] = "You don't have access to this resource.";
                return new BadRequestResult();
            }
            return new NotFoundResult();
        }

        // POST: MatchReviewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            MatchReview? review = await _context.MatchReviews.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(review != null)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (review.UserId == currentUser.Id)
                {
                    ViewData["Title"] = "Delete Review";
                    return View(review);
                }
                TempData["Error"] = "You don't have access to this resource.";
                return new BadRequestResult();
            }
            return new NotFoundResult();
          
        }

        // POST: MatchReviewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            MatchReview? review = await _context.MatchReviews.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (review != null)
            {
                //esnure the current authenticated user owns this resouce //
                var currentUser = await _userManager.GetUserAsync(User);
                if (review.UserId == currentUser.Id)
                {
                    try
                    {
                        _context.MatchReviews.Remove(review);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Details", "SportsMatches", new { id = review.MatchId});

                    }
                    catch (Exception e)
                    {
                        TempData["Error"] = e.Message;
                        return View(review);
                    }
                }           
                TempData["Error"] = "You don't have access to this resource.";
                return new BadRequestResult();
            }
            return new NotFoundResult();
            
        }
    }
}
