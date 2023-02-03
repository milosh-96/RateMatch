using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RateMatch.Mvc.Migrations
{
    public partial class AddCountriesTableAndReferenceCountryInCompetition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Competitions");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Competitions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    CountryCode = table.Column<string>(type: "varchar(256)", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CountryId",
                table: "Competitions",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Countries_CountryId",
                table: "Competitions",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Countries_CountryId",
                table: "Competitions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_CountryId",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Competitions");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Competitions",
                type: "varchar(256)",
                nullable: false,
                defaultValue: "");
        }
    }
}
