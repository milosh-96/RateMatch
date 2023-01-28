namespace RateMatch.Mvc
{
    public static class SiteInfo
    {
        public static string Name { get; set; } = "Rate Match";
        public static string FullName { get; set; } = "Rate Match Inc.";

        public static string Domain { get; set; } = "rate-match.com";
        public static string SiteUrl { get; set; } = "https://"+Domain;
        public static string AssetsUrl { get; set; } = "https://uploads."+Domain;
        public static string NoReplyEmail { get; set; } = "no-reply@"+Domain;
    }
}

