using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateMatch.Mvc.Data
{
    public class Country
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Name { get; set; } = "";
        [Column(TypeName = "varchar(256)")]
        public string CountryCode { get; set; } = "";
        public float Latitude { get; set; } = 0.0f;
        public float Longitude { get; set; } = 0.0f;

        public List<Competition> Competitions { get; set; } = new List<Competition>();
    }
}
