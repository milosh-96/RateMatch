using Microsoft.AspNetCore.Mvc;
using RateMatch.Mvc.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RateMatch.Mvc.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("{area}/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        // GET: api/<MatchesController>
        [HttpGet]
        public List<SportsMatch> Get()
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
                    Id = 2,
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
                    Id = 3,
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
            return matches;
        }

        // GET api/<MatchesController>/5
        [HttpGet("{id}")]
        public List<SportsMatch> Get(int id)
        {
            // temporaraly use like this!!!//
            return this.Get().Where(x=>x.Id==1).ToList();
        }

        // POST api/<MatchesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
