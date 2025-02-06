using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyncScene.DB.Migrations
{
    /// <inheritdoc />
    public partial class addedcreatedbytoeventandlocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Event",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Event",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    SubscribedEventsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.SubscribedEventsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_EventUser_Event_SubscribedEventsId",
                        column: x => x.SubscribedEventsId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_CreatedById",
                table: "Event",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_UsersId",
                table: "EventUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_User_CreatedById",
                table: "Event",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_User_CreatedById",
                table: "Event");

            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.DropIndex(
                name: "IX_Event_CreatedById",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Event");
        }
    }
}
