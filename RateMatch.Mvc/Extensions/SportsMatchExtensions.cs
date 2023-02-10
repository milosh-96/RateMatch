using RateMatch.Mvc.Data;
using Schema.NET;

namespace RateMatch.Mvc.Extensions
{
    public static class SportsMatchExtensions
    {
        public static string ToJsonLd(this SportsMatch item)
        {
            var product = new Product();
            if(item.Reviews != null && item.Reviews.Count > 0)
            {
                var aggregateRating = new AggregateRating()
                {
                    RatingValue = item.Reviews.Average(x => x.ReviewRating),
                    ReviewCount = item.Reviews.Count
                };
                product.AggregateRating = aggregateRating;
            }
            product.Name = item.MatchName + " " + item.MatchResult;
            if(item.Competition != null)
            {
                product.Description = item.Competition != null ? item.Competition.Name : "";
                if (item.Competition != null && item.Competition.Sport != null)
                {
                    product.Description += " (" + item.Competition.Sport.Name + ")";
                    product.Name += " - " + item.Competition.Sport.Name;
                }
            }
            List<Review> reviewsCollection = new List<Review>();
            item.Reviews.ForEach(x => reviewsCollection.Add(new Review()
            {
                Author = new Person() { Name = x.User.UserName },
                DatePublished = x.UpdatedAt,
                ReviewBody = x.ReviewContent,
                ReviewRating = new Rating()
                {
                    RatingValue = x.ReviewRating,
                }
            }));
            var reviews = new OneOrMany<IReview>(reviewsCollection);

            product.Review = reviews;
            return product.ToHtmlEscapedString();
           
        }
    }
}
