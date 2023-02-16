using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RateMatch.Mvc.Migrations
{
    public partial class AddExternalContentLinksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExternalContentLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ExternalUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalContentLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalContentLinkSportsMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SportsMatchId = table.Column<int>(type: "integer", nullable: false),
                    ExternalContentLinkId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalContentLinkSportsMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalContentLinkSportsMatches_ExternalContentLinks_Exter~",
                        column: x => x.ExternalContentLinkId,
                        principalTable: "ExternalContentLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalContentLinkSportsMatches_SportsMatches_SportsMatchId",
                        column: x => x.SportsMatchId,
                        principalTable: "SportsMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_ExternalContentLinkSportsMatches_ExternalContentLinkId",
                table: "ExternalContentLinkSportsMatches",
                column: "ExternalContentLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalContentLinkSportsMatches_SportsMatchId_ExternalCont~",
                table: "ExternalContentLinkSportsMatches",
                columns: new[] { "SportsMatchId", "ExternalContentLinkId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalContentLinkSportsMatches");

            migrationBuilder.DropTable(
                name: "ExternalContentLinks");

           
        }
    }
}
