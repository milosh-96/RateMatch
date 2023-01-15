namespace RateMatch.Mvc.Data
{
    public class SportsMatch
    {
        public int Id { get; set; }
        public string MatchName { get; set; } = "";
        public string MatchResult { get; set; } = "0:0";
        public string Sport { get; set; } = "";
        public string Competition { get; set; } = "";

        public DateTime PlayedAt { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<MatchReview> Reviews { get; set; } = new List<MatchReview>();
    }
}
