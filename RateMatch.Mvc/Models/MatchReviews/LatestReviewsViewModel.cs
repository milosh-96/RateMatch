using RateMatch.Mvc.Data;

namespace RateMatch.Mvc.Models.MatchReviews
{
    public class LatestReviewsViewModel
    {
        public List<MatchReview> Items { get; set; } = new List<MatchReview>();
    }
}
