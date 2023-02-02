using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RateMatch.Mvc.Data;
using RateMatch.Mvc.Data.IdentityEntities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RateMatch.Mvc.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("{area}/[controller]")]
    [ApiController]
    public class MatchReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MatchReviewsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/<MatchReviewsController>
        [HttpGet]
        public IEnumerable<MatchReview> Get()
        {
            return _context.MatchReviews.ToList();

        } 
        // GET: api/<MatchReviewsController>
        [HttpGet("bymatch/{matchId:int}")]
        public IEnumerable<MatchReview> GetByMatch(int matchId)
        {
            return _context.SportsMatches
                .Where(x => x.Id == matchId)
                .Include(x => x.Reviews).ThenInclude(x=>x.User)
                .FirstOrDefault().Reviews;
        }

        // GET api/<MatchReviewsController>/5
        [HttpGet("{id:int}")]
        public MatchReview Get(int id)
        {
            return _context.MatchReviews.Where(x => x.Id == id).Include(x=>x.User).FirstOrDefault();
        }

        // POST api/<MatchReviewsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post(int id, [FromBody] MatchReviewDto values)
        {
            MatchReview review = new MatchReview();
            review.UserId = _userManager.GetUserAsync(User).Result.Id;
            review.AuthorName = values.AuthorName;
            review.ReviewContent = values.ReviewContent;
            review.ReviewRating = values.ReviewRating;
            review.EditKey = Guid.NewGuid();
            review.MatchId = id;
            _context.MatchReviews.Add(review);
            _context.SaveChanges();
            return new JsonResult(review);
        }

        // PUT api/<MatchReviewsController>/5
        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MatchReviewsController>/5
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
        }
    }
}
