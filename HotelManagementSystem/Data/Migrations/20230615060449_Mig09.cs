using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Data.Migrations
{
    public partial class Mig09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServicePrices_ServicePriceId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServicePriceId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServicePriceId",
                table: "Services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServicePriceId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServicePriceId",
                table: "Services",
                column: "ServicePriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServicePrices_ServicePriceId",
                table: "Services",
                column: "ServicePriceId",
                principalTable: "ServicePrices",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
