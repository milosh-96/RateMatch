using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RateMatch.Mvc.Data.IdentityEntities;
using RateMatch.Mvc.Data;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

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


            //enable this code only if you need to add seeding to next migration after seeding //
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = 1, Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = 2, Name = "Editor", NormalizedName = "Editor".ToUpper() });

            // assume the first user should be an admin !!//
            //Seeding the relation between our user and role to AspNetUserRoles table
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    RoleId = 1,
                    UserId = 1
                }
            );

            builder
                .Entity<MatchReview>()
                .Property(b => b.EditKey)
                .HasValueGenerator<GuidValueGenerator>();

            builder.Entity<MatchReview>()
                .HasOne(u => u.User)
                .WithMany(x=>x.Reviews).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SportsMatchVideoPost>().HasIndex(
                sv => new { sv.SportsMatchId, sv.VideoPostId })
                .IsUnique();
            builder.Entity<ExternalContentLinkSportsMatch>().HasIndex(
                es => new { es.SportsMatchId, es.ExternalContentLinkId })
                .IsUnique();
        }
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<SportsMatch> SportsMatches => Set<SportsMatch>();
        public DbSet<MatchReview> MatchReviews => Set<MatchReview>();
        public DbSet<Competition> Competitions => Set<Competition>();
        public DbSet<Sport> Sports => Set<Sport>();
        public DbSet<VideoPost> VideoPosts => Set<VideoPost>();
        public DbSet<SportsMatchVideoPost> SportsMatchVideoPosts => Set<SportsMatchVideoPost>();
        public DbSet<ExternalContentLink> ExternalContentLinks => Set<ExternalContentLink>();
        public DbSet<ExternalContentLinkSportsMatch> ExternalContentLinkSportsMatches => Set<ExternalContentLinkSportsMatch>();
    }
}