using Microsoft.EntityFrameworkCore.Migrations;

namespace RepoLayer.Migrations
{
    public partial class RemoveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_CreatedBy",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CreatedBy",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Notes");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserID",
                table: "Notes",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserID",
                table: "Notes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserID",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserID",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CreatedBy",
                table: "Notes",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_CreatedBy",
                table: "Notes",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
