using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RateMatch.Mvc.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RateMatch.Mvc.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("{area}/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<MatchesController>
        [HttpGet]
        public async Task<List<SportsMatch>> Get()
        {
            List<SportsMatch> matches = await _context.SportsMatches.ToListAsync();
            matches.ForEach(x => x.Url = Url.Action(
                        "Details", "SportsMatches",
                        new { id = x.Id, slug = x.Slug, area=""}));
            return matches.OrderByDescending(x=>x.PlayedAt).ToList();
        }

        // GET api/<MatchesController>/5
        [HttpGet("{id}")]
        public async Task<SportsMatch?> Get(int id)
        {
            return await _context.SportsMatches.Where(x => x.Id == id).Include(x=>x.Reviews).FirstOrDefaultAsync();
        }

        // POST api/<MatchesController>
        [HttpPost]
        public SportsMatch Post([FromBody] SportsMatchDto value)
        {
            return new SportsMatch() { MatchName=value.MatchName};
        }

        // PUT api/<MatchesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MatchesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
