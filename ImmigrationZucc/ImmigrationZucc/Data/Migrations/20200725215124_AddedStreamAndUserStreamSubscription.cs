using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmigrationZucc.Data.Migrations
{
    public partial class AddedStreamAndUserStreamSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    StreamId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StreamType = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streams", x => x.StreamId);
                });

            migrationBuilder.CreateTable(
                name: "UserStreamSubscriptions",
                columns: table => new
                {
                    UserStreamSubscriptionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    StreamId = table.Column<long>(nullable: false),
                    SubscribedDateTime = table.Column<DateTime>(nullable: true),
                    CancelledDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStreamSubscriptions", x => x.UserStreamSubscriptionId);
                    table.ForeignKey(
                        name: "FK_UserStreamSubscriptions_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "StreamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStreamSubscriptions_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStreamSubscriptions_StreamId",
                table: "UserStreamSubscriptions",
                column: "StreamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStreamSubscriptions_UserId1",
                table: "UserStreamSubscriptions",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStreamSubscriptions");

            migrationBuilder.DropTable(
                name: "Streams");
        }
    }
}
