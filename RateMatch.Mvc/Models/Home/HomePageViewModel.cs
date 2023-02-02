using RateMatch.Mvc.Data;

namespace RateMatch.Mvc.Models.Home
{
    public class HomePageViewModel
    {
        public List<SportsMatch>? Matches { get; set; } = new List<SportsMatch>();
        public List<MatchReview>? Reviews { get; set; } = new List<MatchReview>();
    }
}
