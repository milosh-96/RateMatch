using RateMatch.Mvc.Data;

namespace RateMatch.Mvc.Views.MatchReviews.Partials
{
    public class MatchReviewFormViewModel
    {
        public SportsMatch? SportsMatch { get; set; }
        public MatchReviewDto ReviewForm { get; set; } = new MatchReviewDto() { ReviewContent = String.Empty };
    }
}
