using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateMatch.Mvc.Migrations
{
    public partial class NullableUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchReviews_AspNetUsers_UserId",
                table: "MatchReviews");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MatchReviews",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchReviews_AspNetUsers_UserId",
                table: "MatchReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchReviews_AspNetUsers_UserId",
                table: "MatchReviews");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MatchReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchReviews_AspNetUsers_UserId",
                table: "MatchReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
