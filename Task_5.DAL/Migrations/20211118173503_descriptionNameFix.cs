using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_5.DAL.Migrations
{
    public partial class descriptionNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Rooms",
                newName: "Decription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Decription",
                table: "Rooms",
                newName: "Description");
        }
    }
}
