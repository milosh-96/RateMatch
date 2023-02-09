using Microsoft.AspNetCore.Mvc;
using RateMatch.Mvc.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RateMatch.Mvc.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("{area}/[controller]")]
    [ApiController]
    public class CompetitionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompetitionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<CompetitionController>
        [HttpGet]
        public List<Competition> Get()
        {
            return _context.Competitions.ToList();
        }

        // GET api/<CompetitionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompetitionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CompetitionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompetitionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
