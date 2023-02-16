using Microsoft.AspNetCore.Identity;
using RateMatch.Mvc.Data;

namespace RateMatch.Mvc.Models.SportsMatches
{
    public class SportsMatchDetailsViewModel
    {
        public bool IsLoggedIn { get; set; } = false;
        public SportsMatch Item { get; set; } = new SportsMatch();

        public List<VideoPost> VideoPosts { get; set; } = new List<VideoPost>();
        public List<ExternalContentLink> Links { get; set; } = new List<ExternalContentLink>();
        public MatchReviewDto ReviewForm { get; set; } = new MatchReviewDto() { ReviewContent=String.Empty};
    }
}
