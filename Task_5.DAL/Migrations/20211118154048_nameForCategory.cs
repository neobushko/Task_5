using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_5.DAL.Migrations
{
    public partial class nameForCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Prices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Categories");
        }
    }
}
