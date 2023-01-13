using RateMatch.Mvc.Data.IdentityEntities;

namespace RateMatch.Mvc.Data
{
    public class MatchReview
    {
        public int Id { get; set; }
        public string ReviewContent { get; set; } = "";
        public int ReviewRating { get; set; } = 5;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public ApplicationUser  User { get; set; }

        public int MatchId { get; set; }
        public SportsMatch Match { get; set; } = new SportsMatch();
    }
}
