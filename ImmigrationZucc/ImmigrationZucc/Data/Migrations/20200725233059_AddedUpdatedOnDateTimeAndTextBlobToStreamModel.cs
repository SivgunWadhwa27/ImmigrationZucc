using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationZucc.Data.Migrations
{
    public partial class AddedUpdatedOnDateTimeAndTextBlobToStreamModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TextBlob",
                table: "Streams",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnDateTime",
                table: "Streams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextBlob",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "UpdatedOnDateTime",
                table: "Streams");
        }
    }
}
