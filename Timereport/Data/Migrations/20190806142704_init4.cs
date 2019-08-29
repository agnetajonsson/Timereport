using Microsoft.EntityFrameworkCore.Migrations;

namespace Timereport.Data.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "reason",
                table: "OneUser",
                newName: "Reason");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "OneUser",
                newName: "reason");
        }
    }
}
