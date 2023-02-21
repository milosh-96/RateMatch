using System.ComponentModel.DataAnnotations.Schema;

namespace RateMatch.Mvc.Data
{
    public class VideoPost
    {
        public int Id { get; set; }

        public string Title { get; set; } = "Untitled";

        [Column(TypeName ="varchar(256)")]
        public string Source { get; set; } = "undefined";

        public string? VideoSourceUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<SportsMatchVideoPost> SportsMatches { get; set; } = new List<SportsMatchVideoPost>();


        public string GetVideoUrl()
        {
            if (Source == "YouTube")
            {
                if (VideoSourceUrl != null && VideoSourceUrl.Length > 0)
                {
                    if (VideoSourceUrl.StartsWith("https://www.youtube.com/watch?v="))
                    {
                        return VideoSourceUrl.Replace("watch?v=", "embed/");
                    }
                }
            }
            return this.VideoSourceUrl ?? "";
        }


    }
    public class VideoPostDto
    {
        public string Title { get; set; } = "";
        public string? VideoSourceUrl { get; set; }
        public string Source { get; set; } = "Undefined";

    }

    public class SportsMatchVideoPost
    {
        public int Id { get; set; }
        public int SportsMatchId { get; set; }
        public SportsMatch? SportsMatch { get; set; }
        public int VideoPostId { get; set; }
        public VideoPost? VideoPost { get; set; }
    }
}
