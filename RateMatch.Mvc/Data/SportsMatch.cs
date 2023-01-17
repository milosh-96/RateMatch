using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Routing;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

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
        [Column(TypeName = "varchar(256)")]
        public string Sport { get; set; } = "";
        [Column(TypeName = "varchar(256)")]
        public string Competition { get; set; } = "";

        public DateTime PlayedAt { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<MatchReview> Reviews { get; set; } = new List<MatchReview>();


        [NotMapped]
        public string Url { get; set; } = "";
    }


    public class SportsMatchDto
    {
        public string MatchName { get; set; } = "";
        public string MatchResult { get; set; } = "";
        public string Sport { get; set; } = "";
        public string Competition { get; set; } = "";
        public string PlayedAt { get; set; } = "";

       
    }
}
