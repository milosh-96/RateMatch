using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RateMatch.Mvc.Migrations
{
    public partial class AddVideoPostsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    SourceUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportsMatchVideoPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SportsMatchId = table.Column<int>(type: "integer", nullable: false),
                    VideoPostId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsMatchVideoPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportsMatchVideoPosts_SportsMatches_SportsMatchId",
                        column: x => x.SportsMatchId,
                        principalTable: "SportsMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportsMatchVideoPosts_VideoPosts_VideoPostId",
                        column: x => x.VideoPostId,
                        principalTable: "VideoPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportsMatchVideoPosts_SportsMatchId_VideoPostId",
                table: "SportsMatchVideoPosts",
                columns: new[] { "SportsMatchId", "VideoPostId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SportsMatchVideoPosts_VideoPostId",
                table: "SportsMatchVideoPosts",
                column: "VideoPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportsMatchVideoPosts");

            migrationBuilder.DropTable(
                name: "VideoPosts");

          
        }
    }
}
