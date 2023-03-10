using RateMatch.Mvc.Data;

namespace RateMatch.Mvc.Views.MatchReviews.Partials
{
    public class MatchReviewItemPartialViewModel
    {
        public MatchReview Item { get; set; } = new MatchReview();
        public bool IsCurrentUserItem { get; set; } = false;
    }
}
