using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Data.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentCategories",
                columns: table => new
                {
                    ApartmentCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentCategories", x => x.ApartmentCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentDailyPrices",
                columns: table => new
                {
                    ApartmentDailyPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentDailyPrices", x => x.ApartmentDailyPriceId);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentStatuses",
                columns: table => new
                {
                    ApartmentStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentStatuses", x => x.ApartmentStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentTypes",
                columns: table => new
                {
                    ApartmentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentTypes", x => x.ApartmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentServices",
                columns: table => new
                {
                    EnrollmentServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentServices", x => x.EnrollmentServiceId);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentTypes",
                columns: table => new
                {
                    EnrollmentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentTypes", x => x.EnrollmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "PassportInfo",
                columns: table => new
                {
                    PassportInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirtstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportInfo", x => x.PassportInfoId);
                });

            migrationBuilder.CreateTable(
                name: "ServicePrices",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePrices", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentName = table.Column<int>(type: "int", nullable: false),
                    DaysOccupied = table.Column<int>(type: "int", nullable: false),
                    ApartmentTypeId = table.Column<int>(type: "int", nullable: false),
                    ApartmentCategoryId = table.Column<int>(type: "int", nullable: false),
                    ApartmentStatusId = table.Column<int>(type: "int", nullable: false),
                    ApartmentDailyPriceId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.ApartmentId);
                    table.ForeignKey(
                        name: "FK_Apartments_ApartmentCategories_ApartmentCategoryId",
                        column: x => x.ApartmentCategoryId,
                        principalTable: "ApartmentCategories",
                        principalColumn: "ApartmentCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartments_ApartmentDailyPrices_ApartmentDailyPriceId",
                        column: x => x.ApartmentDailyPriceId,
                        principalTable: "ApartmentDailyPrices",
                        principalColumn: "ApartmentDailyPriceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartments_ApartmentStatuses_ApartmentStatusId",
                        column: x => x.ApartmentStatusId,
                        principalTable: "ApartmentStatuses",
                        principalColumn: "ApartmentStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartments_ApartmentTypes_ApartmentTypeId",
                        column: x => x.ApartmentTypeId,
                        principalTable: "ApartmentTypes",
                        principalColumn: "ApartmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartments_EnrollmentServices_EnrollmentServiceId",
                        column: x => x.EnrollmentServiceId,
                        principalTable: "EnrollmentServices",
                        principalColumn: "EnrollmentServiceId");
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Discont = table.Column<double>(type: "float", nullable: false),
                    PassportInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                    table.ForeignKey(
                        name: "FK_Guests_PassportInfo_PassportInfoId",
                        column: x => x.PassportInfoId,
                        principalTable: "PassportInfo",
                        principalColumn: "PassportInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Info = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EnrollmentServiceId = table.Column<int>(type: "int", nullable: false),
                    ServicePriceId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_EnrollmentServices_EnrollmentServiceId",
                        column: x => x.EnrollmentServiceId,
                        principalTable: "EnrollmentServices",
                        principalColumn: "EnrollmentServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_ServicePrices_ServicePriceId",
                        column: x => x.ServicePriceId,
                        principalTable: "ServicePrices",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdultsNumber = table.Column<int>(type: "int", nullable: false),
                    ChildrenNumber = table.Column<int>(type: "int", nullable: false),
                    CheckSum = table.Column<double>(type: "float", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentTypeId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_EnrollmentServices_EnrollmentServiceId",
                        column: x => x.EnrollmentServiceId,
                        principalTable: "EnrollmentServices",
                        principalColumn: "EnrollmentServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_EnrollmentTypes_EnrollmentTypeId",
                        column: x => x.EnrollmentTypeId,
                        principalTable: "EnrollmentTypes",
                        principalColumn: "EnrollmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartmentCategoryId",
                table: "Apartments",
                column: "ApartmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartmentDailyPriceId",
                table: "Apartments",
                column: "ApartmentDailyPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartmentStatusId",
                table: "Apartments",
                column: "ApartmentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartmentTypeId",
                table: "Apartments",
                column: "ApartmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_EnrollmentServiceId",
                table: "Apartments",
                column: "EnrollmentServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ApartmentId",
                table: "Enrollments",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentServiceId",
                table: "Enrollments",
                column: "EnrollmentServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentTypeId",
                table: "Enrollments",
                column: "EnrollmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_GuestId",
                table: "Enrollments",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_PassportInfoId",
                table: "Guests",
                column: "PassportInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_EnrollmentServiceId",
                table: "Services",
                column: "EnrollmentServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServicePriceId",
                table: "Services",
                column: "ServicePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "EnrollmentTypes");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "ServicePrices");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "ApartmentCategories");

            migrationBuilder.DropTable(
                name: "ApartmentDailyPrices");

            migrationBuilder.DropTable(
                name: "ApartmentStatuses");

            migrationBuilder.DropTable(
                name: "ApartmentTypes");

            migrationBuilder.DropTable(
                name: "EnrollmentServices");

            migrationBuilder.DropTable(
                name: "PassportInfo");
        }
    }
}
