using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateMatch.Mvc.Data
{
    public class Sport
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Name { get; set; } = "";

        [Column(TypeName = "varchar(256)")]
        public string Slug { get; set; } = "";
    }
}
