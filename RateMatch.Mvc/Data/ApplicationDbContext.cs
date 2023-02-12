using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RateMatch.Mvc.Data.IdentityEntities;
using RateMatch.Mvc.Data;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.CodeAnalysis;

namespace RateMatch.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            builder
                .Entity<MatchReview>()
                .Property(b => b.EditKey)
                .HasValueGenerator<GuidValueGenerator>();

            builder.Entity<MatchReview>()
                .HasOne(u => u.User)
                .WithMany(x=>x.Reviews).OnDelete(DeleteBehavior.Cascade);
          
        }
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<SportsMatch> SportsMatches => Set<SportsMatch>();
        public DbSet<MatchReview> MatchReviews => Set<MatchReview>();
        public DbSet<Competition> Competitions => Set<Competition>();
        public DbSet<Sport> Sports => Set<Sport>();
    }
}