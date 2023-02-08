﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateMatch.Mvc.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchReviews_AspNetUsers_UserId",
                table: "MatchReviews");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchReviews_AspNetUsers_UserId",
                table: "MatchReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchReviews_AspNetUsers_UserId",
                table: "MatchReviews");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchReviews_AspNetUsers_UserId",
                table: "MatchReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
