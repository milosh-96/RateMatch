using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateMatch.Mvc.Migrations
{
    public partial class AddSourceToExternalCLinksAndVideoPots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SourceUrl",
                table: "VideoPosts",
                newName: "VideoSourceUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "VideoPosts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "VideoPosts",
                type: "varchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ExternalContentLinks",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "ExternalUrl",
                table: "ExternalContentLinks",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "ExternalContentLinks",
                type: "varchar(256)",
                nullable: false,
                defaultValue: "");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "VideoPosts");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "ExternalContentLinks");

            migrationBuilder.RenameColumn(
                name: "VideoSourceUrl",
                table: "VideoPosts",
                newName: "SourceUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "VideoPosts",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ExternalContentLinks",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ExternalUrl",
                table: "ExternalContentLinks",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

           
        }
    }
}
