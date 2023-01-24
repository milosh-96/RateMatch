using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace RateMatch.Mvc.Data.IdentityEntities
{
    public class ApplicationUser : IdentityUser<int>
    {
        [JsonIgnore]
        public override string? PasswordHash { get; set; }
    }
}
