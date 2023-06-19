using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Data.Migrations
{
    public partial class Mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_EnrollmentServices_EnrollmentServiceId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_EnrollmentServiceId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "EnrollmentServiceId",
                table: "Apartments");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Guests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Guests");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentServiceId",
                table: "Apartments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_EnrollmentServiceId",
                table: "Apartments",
                column: "EnrollmentServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_EnrollmentServices_EnrollmentServiceId",
                table: "Apartments",
                column: "EnrollmentServiceId",
                principalTable: "EnrollmentServices",
                principalColumn: "EnrollmentServiceId");
        }
    }
}
