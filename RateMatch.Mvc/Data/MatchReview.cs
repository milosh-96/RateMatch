using System.Text.Json.Serialization;
using RateMatch.Mvc.Data.IdentityEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateMatch.Mvc.Data
{
    public class MatchReview
    {
        public int Id { get; set; }

        public string ReviewContent { get; set; } = "";
        public int ReviewRating { get; set; } = 5;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column(TypeName ="varchar(256)")]
        public string? AuthorName { get; set; } = "Guest";

        public Guid EditKey { get; set; } = Guid.NewGuid();

        public int? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public int MatchId { get; set; }

        [JsonIgnore]
        public SportsMatch? Match { get; set; }
    }


    public class MatchReviewDto
    {
        [Required]
        [StringLength(2000,MinimumLength =5)]
        public string? ReviewContent { get; set; }

        [Required]
        public int ReviewRating { get; set; } = 5;

        public string AuthorName { get; set; } = "Guest";
      
    }
}
