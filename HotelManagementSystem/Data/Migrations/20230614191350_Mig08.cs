using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Data.Migrations
{
    public partial class Mig08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_ApartmentDailyPrices_ApartmentDailyPriceId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_ApartmentDailyPriceId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ApartmentDailyPriceId",
                table: "Apartments");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Services",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DailyPrice",
                table: "Apartments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DailyPrice",
                table: "Apartments");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentDailyPriceId",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartmentDailyPriceId",
                table: "Apartments",
                column: "ApartmentDailyPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_ApartmentDailyPrices_ApartmentDailyPriceId",
                table: "Apartments",
                column: "ApartmentDailyPriceId",
                principalTable: "ApartmentDailyPrices",
                principalColumn: "ApartmentDailyPriceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
