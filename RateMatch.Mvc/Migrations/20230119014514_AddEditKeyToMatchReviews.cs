using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateMatch.Mvc.Migrations
{
    public partial class AddEditKeyToMatchReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EditKey",
                table: "MatchReviews",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditKey",
                table: "MatchReviews");
        }
    }
}
