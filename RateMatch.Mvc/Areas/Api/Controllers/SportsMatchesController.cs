using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RateMatch.Mvc.Data;
using RateMatch.Mvc.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RateMatch.Mvc.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("{area}/[controller]")]
    [ApiController]
    public class SportsMatchesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly MatchService _matchService;

        public SportsMatchesController(MatchService matchService,ApplicationDbContext context)
        {
            _matchService = matchService;
            _context = context;
        }


        // GET: api/<MatchesController>
        [HttpGet]
        public async Task<List<SportsMatch>> Get()
        {
            List<SportsMatch> matches = await _matchService.GetAllAsync();
            matches.ForEach(x => {
                if (x.Id > 0 && x.Slug != null)
                {
                    x.Url = Url.Action(
                            "Details", "SportsMatches",
                            new { id = x.Id, slug = x.Slug, area = "" }
                            ) ?? "";
                }
                });

            return matches.OrderByDescending(x=>x.PlayedAt).ToList();
        }

        // GET api/<MatchesController>/5
        [HttpGet("{id}")]
        public async Task<SportsMatch?> Get(int id)
        {
            return await _matchService.SingleAsync(id);
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
