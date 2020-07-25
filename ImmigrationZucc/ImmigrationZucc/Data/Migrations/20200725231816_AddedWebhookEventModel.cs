using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationZucc.Data.Migrations
{
    public partial class AddedWebhookEventModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreamType",
                table: "Streams");

            migrationBuilder.AddColumn<string>(
                name: "StreamCode",
                table: "Streams",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WebhookEvents",
                columns: table => new
                {
                    WebhookEventId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceUri = table.Column<string>(nullable: true),
                    StreamCode = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebhookEvents", x => x.WebhookEventId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebhookEvents");

            migrationBuilder.DropColumn(
                name: "StreamCode",
                table: "Streams");

            migrationBuilder.AddColumn<int>(
                name: "StreamType",
                table: "Streams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
