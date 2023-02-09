using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RateMatch.Mvc.Data
{
    public class Competition
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Name { get; set; } = "";

        [Column(TypeName = "varchar(256)")]
        public string Slug { get; set; } = "";

        [JsonIgnore]
        public Sport? Sport { get; set; }
        public int? SportId { get; set; }

        [JsonIgnore]
        public Country? Country { get; set; }
        public int? CountryId { get; set; }

        public List<SportsMatch> Matches { get; set; } = new List<SportsMatch>();
    }
}
