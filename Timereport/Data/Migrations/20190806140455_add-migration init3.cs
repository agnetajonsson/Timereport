using Microsoft.EntityFrameworkCore.Migrations;

namespace Timereport.Data.Migrations
{
    public partial class addmigrationinit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogoutTimne",
                table: "OneUser",
                newName: "LogoutTime");

            migrationBuilder.AddColumn<string>(
                name: "reason",
                table: "OneUser",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reason",
                table: "OneUser");

            migrationBuilder.RenameColumn(
                name: "LogoutTime",
                table: "OneUser",
                newName: "LogoutTimne");
        }
    }
}
