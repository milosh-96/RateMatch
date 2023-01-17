using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RateMatch.Mvc.Data.IdentityEntities;
using RateMatch.Mvc.Data;

namespace RateMatch.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SportsMatch> SportsMatches => Set<SportsMatch>();
        public DbSet<MatchReview> MatchReviews => Set<MatchReview>();
    }
}