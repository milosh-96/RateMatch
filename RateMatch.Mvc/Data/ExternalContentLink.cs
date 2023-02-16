using System.ComponentModel.DataAnnotations.Schema;

namespace RateMatch.Mvc.Data
{
    public class ExternalContentLink
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Source { get; set; } = "undefined";

        public string Title { get; set; } = ""; 
        
        public string ExternalUrl { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<ExternalContentLinkSportsMatch> SportsMatches { get; set; } = new List<ExternalContentLinkSportsMatch>();

        public override string ToString()
        {
            return String.Format("{0}: {1}", this.Source, this.Title);
        }

    }

    public class ExternalContentLinkSportsMatch
    {
        public int Id { get; set; }
        public int SportsMatchId { get; set; }
        public SportsMatch? SportsMatch { get; set; }
        public int ExternalContentLinkId { get; set; }
        public ExternalContentLink? ExternalContentLink { get; set; }

    }
}
