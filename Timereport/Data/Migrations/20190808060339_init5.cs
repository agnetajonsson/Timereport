using Microsoft.EntityFrameworkCore.Migrations;

namespace Timereport.Data.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "OneUser",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OneUser",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OneUser_UserId",
                table: "OneUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OneUser_AspNetUsers_UserId",
                table: "OneUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OneUser_AspNetUsers_UserId",
                table: "OneUser");

            migrationBuilder.DropIndex(
                name: "IX_OneUser_UserId",
                table: "OneUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "OneUser",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OneUser",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
