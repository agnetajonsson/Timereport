using Microsoft.EntityFrameworkCore.Migrations;

namespace Timereport.Data.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OneUser_AspNetUsers_UserId",
                table: "OneUser");

            migrationBuilder.DropIndex(
                name: "IX_OneUser_UserId",
                table: "OneUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OneUser",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
