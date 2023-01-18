using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateMatch.Mvc.Migrations
{
    public partial class AddGuestAuthorToMatchReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "MatchReviews",
                type: "varchar(256)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "MatchReviews");
        }
    }
}
