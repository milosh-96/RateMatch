using Microsoft.AspNetCore.Mvc.Rendering;
using RateMatch.Mvc.Data;

namespace RateMatch.Mvc.Models.MatchReviews
{
    public class MatchReviewEditViewModel
    {
        public MatchReview? Item { get; set; }

        public SelectList? RatingChoices;
    }
}
