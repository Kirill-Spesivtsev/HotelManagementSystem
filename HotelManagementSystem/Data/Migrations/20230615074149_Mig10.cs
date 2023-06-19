using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Data.Migrations
{
    public partial class Mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_EnrollmentServices_EnrollmentServiceId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_EnrollmentServices_EnrollmentServiceId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_EnrollmentServiceId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_EnrollmentServiceId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "EnrollmentServiceId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CheckSum",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "EnrollmentServiceId",
                table: "Enrollments");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "EnrollmentServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentId",
                table: "EnrollmentServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "EnrollmentServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "BookingOnly",
                table: "Enrollments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "PrePaid",
                table: "Enrollments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentServices_EnrollmentId",
                table: "EnrollmentServices",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentServices_ServiceId",
                table: "EnrollmentServices",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentServices_Enrollments_EnrollmentId",
                table: "EnrollmentServices",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "EnrollmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentServices_Services_ServiceId",
                table: "EnrollmentServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentServices_Enrollments_EnrollmentId",
                table: "EnrollmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentServices_Services_ServiceId",
                table: "EnrollmentServices");

            migrationBuilder.DropIndex(
                name: "IX_EnrollmentServices_EnrollmentId",
                table: "EnrollmentServices");

            migrationBuilder.DropIndex(
                name: "IX_EnrollmentServices_ServiceId",
                table: "EnrollmentServices");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "EnrollmentServices");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "EnrollmentServices");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "EnrollmentServices");

            migrationBuilder.DropColumn(
                name: "BookingOnly",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "PrePaid",
                table: "Enrollments");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentServiceId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "CheckSum",
                table: "Enrollments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentServiceId",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_EnrollmentServiceId",
                table: "Services",
                column: "EnrollmentServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentServiceId",
                table: "Enrollments",
                column: "EnrollmentServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_EnrollmentServices_EnrollmentServiceId",
                table: "Enrollments",
                column: "EnrollmentServiceId",
                principalTable: "EnrollmentServices",
                principalColumn: "EnrollmentServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_EnrollmentServices_EnrollmentServiceId",
                table: "Services",
                column: "EnrollmentServiceId",
                principalTable: "EnrollmentServices",
                principalColumn: "EnrollmentServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
