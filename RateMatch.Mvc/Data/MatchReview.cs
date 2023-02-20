﻿using System.Text.Json.Serialization;
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
        [StringLength(2000,MinimumLength =0)]
        public string? ReviewContent { get; set; }

        [Required]
        [Range(1,5,ErrorMessage ="The rating value must be between 1 and 5.")]
        public int ReviewRating { get; set; } = 5;

        [Required(ErrorMessage ="Please enter your name.")]
        [StringLength(25,MinimumLength =5,ErrorMessage ="Your name must be between 5 and 25 letters.")]
        public string AuthorName { get; set; } = "Guest";
      
    }
    
}
