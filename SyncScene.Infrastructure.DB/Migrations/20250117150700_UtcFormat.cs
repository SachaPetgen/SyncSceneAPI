using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyncScene.DB.Migrations
{
    /// <inheritdoc />
    public partial class UtcFormat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                table: "User",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Id",
                table: "User");
        }
    }
}
