using Microsoft.AspNetCore.Identity;
using RateMatch.Mvc.Data;

namespace RateMatch.Mvc.Models.SportsMatches
{
    public class SportsMatchDetailsViewModel
    {
        public bool IsLoggedIn { get; set; } = false;
        public SportsMatch Item { get; set; } = new SportsMatch();
        public MatchReviewDto ReviewForm { get; set; } = new MatchReviewDto() { ReviewContent=" "};
    }
}
