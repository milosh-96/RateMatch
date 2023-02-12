using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Routing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Text.Json.Serialization;

namespace RateMatch.Mvc.Data
{
    public class SportsMatch
    {
        public int Id { get; set; }

        [Column(TypeName ="varchar(256)")]
        public string Slug { get; set; } = "";

        [Column(TypeName = "varchar(256)")]
        public string MatchName { get; set; } = "";

        [Column(TypeName = "varchar(256)")]
        public string MatchResult { get; set; } = "0:0";

        [JsonIgnore]
        public Competition? Competition { get; set; }
        public int? CompetitionId { get; set; } 

        public DateTime PlayedAt { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;




        [JsonIgnore]
        public List<MatchReview> Reviews { get; set; } = new List<MatchReview>();


        [NotMapped]
        public string Url { get; set; } = "";


    }


    public class SportsMatchDto
    {
        [Required]
        public string MatchName { get; set; } = "";

        [Required]
        public string MatchResult { get; set; } = "";

        [Required]
        public int? CompetitionId { get; set; }

        [Required]
        public string PlayedAt { get; set; } = "";
       
    }

}
