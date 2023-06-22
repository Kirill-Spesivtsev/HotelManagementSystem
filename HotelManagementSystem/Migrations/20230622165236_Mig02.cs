using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    public partial class Mig02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnrollmentStatusId",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EnrollmentStatuses",
                columns: table => new
                {
                    EnrollmentStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentStatuses", x => x.EnrollmentStatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentStatusId",
                table: "Enrollments",
                column: "EnrollmentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_EnrollmentStatuses_EnrollmentStatusId",
                table: "Enrollments",
                column: "EnrollmentStatusId",
                principalTable: "EnrollmentStatuses",
                principalColumn: "EnrollmentStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_EnrollmentStatuses_EnrollmentStatusId",
                table: "Enrollments");

            migrationBuilder.DropTable(
                name: "EnrollmentStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_EnrollmentStatusId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "EnrollmentStatusId",
                table: "Enrollments");
        }
    }
}
