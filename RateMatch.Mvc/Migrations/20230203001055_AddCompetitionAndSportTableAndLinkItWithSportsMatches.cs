using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RateMatch.Mvc.Migrations
{
    public partial class AddCompetitionAndSportTableAndLinkItWithSportsMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Competition",
                table: "SportsMatches");

            migrationBuilder.DropColumn(
                name: "Sport",
                table: "SportsMatches");

            migrationBuilder.AddColumn<int>(
                name: "CompetitionId",
                table: "SportsMatches",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Slug = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Slug = table.Column<string>(type: "varchar(256)", nullable: false),
                    SportId = table.Column<int>(type: "integer", nullable: true),
                    Country = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportsMatches_CompetitionId",
                table: "SportsMatches",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_SportId",
                table: "Competitions",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportsMatches_Competitions_CompetitionId",
                table: "SportsMatches",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportsMatches_Competitions_CompetitionId",
                table: "SportsMatches");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_SportsMatches_CompetitionId",
                table: "SportsMatches");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "SportsMatches");

            migrationBuilder.AddColumn<string>(
                name: "Competition",
                table: "SportsMatches",
                type: "varchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sport",
                table: "SportsMatches",
                type: "varchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
