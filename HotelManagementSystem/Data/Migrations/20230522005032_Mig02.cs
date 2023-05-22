using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Data.Migrations
{
    public partial class Mig02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysOccupied",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "Apartments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "Apartments");

            migrationBuilder.AddColumn<int>(
                name: "DaysOccupied",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
