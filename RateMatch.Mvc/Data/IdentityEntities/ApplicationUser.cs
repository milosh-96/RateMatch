using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RateMatch.Mvc.Data.IdentityEntities
{
    public class ApplicationUser : IdentityUser<int>
    {
        [JsonIgnore]
        public override string? PasswordHash
        {
            get { return base.PasswordHash; }
            set { base.PasswordHash = value; }
        }

        public List<MatchReview> Reviews { get; set; } = new List<MatchReview>();
    }
}
