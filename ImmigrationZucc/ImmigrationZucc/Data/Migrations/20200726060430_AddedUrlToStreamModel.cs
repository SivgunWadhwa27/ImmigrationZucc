using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationZucc.Data.Migrations
{
    public partial class AddedUrlToStreamModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Streams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Streams");
        }
    }
}
