using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyncScene.DB.Migrations
{
    /// <inheritdoc />
    public partial class getallgenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Shows",
                table: "Shows");

            migrationBuilder.RenameTable(
                name: "Shows",
                newName: "Show");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Show",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Show",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Show",
                table: "Show",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Show_Name",
                table: "Show",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Show",
                table: "Show");

            migrationBuilder.DropIndex(
                name: "IX_Show_Name",
                table: "Show");

            migrationBuilder.RenameTable(
                name: "Show",
                newName: "Shows");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shows",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Shows",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shows",
                table: "Shows",
                column: "Id");
        }
    }
}
