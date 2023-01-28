using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RateMatch.Mvc.Migrations
{
    public partial class AddSportsMatchesAndReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportsMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Slug = table.Column<string>(type: "varchar(256)", nullable: false),
                    MatchName = table.Column<string>(type: "varchar(256)", nullable: false),
                    MatchResult = table.Column<string>(type: "varchar(256)", nullable: false),
                    Sport = table.Column<string>(type: "varchar(256)", nullable: false),
                    Competition = table.Column<string>(type: "varchar(256)", nullable: false),
                    PlayedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsMatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReviewContent = table.Column<string>(type: "text", nullable: false),
                    ReviewRating = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MatchId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchReviews_SportsMatches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "SportsMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchReviews_MatchId",
                table: "MatchReviews",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchReviews_UserId",
                table: "MatchReviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchReviews");

            migrationBuilder.DropTable(
                name: "SportsMatches");
        }
    }
}
