using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Data.Migrations
{
    public partial class Mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Guests_GuestId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_GuestId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Enrollments");

            migrationBuilder.CreateTable(
                name: "EnrollmentGuest",
                columns: table => new
                {
                    EnrollmentGuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentGuest", x => x.EnrollmentGuestId);
                    table.ForeignKey(
                        name: "FK_EnrollmentGuest_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "EnrollmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollmentGuest_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentGuest_EnrollmentId",
                table: "EnrollmentGuest",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentGuest_GuestId",
                table: "EnrollmentGuest",
                column: "GuestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrollmentGuest");

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_GuestId",
                table: "Enrollments",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Guests_GuestId",
                table: "Enrollments",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
