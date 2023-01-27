using RateMatch.Mvc.Data.IdentityEntities;

namespace RateMatch.Mvc.Extensions
{
    public static class ApplicationUserExtensions
    {
        public static ApplicationUserDto? ToDto(this ApplicationUser user)
        {
           if(user != null)
            {
                return new ApplicationUserDto()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                };
            }
            return null;
        }
    }
}
