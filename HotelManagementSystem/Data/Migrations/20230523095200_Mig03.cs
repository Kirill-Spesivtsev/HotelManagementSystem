using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Data.Migrations
{
    public partial class Mig03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_PassportInfo_PassportInfoId",
                table: "Guests");

            migrationBuilder.DropTable(
                name: "PassportInfo");

            migrationBuilder.RenameColumn(
                name: "PassportInfoId",
                table: "Guests",
                newName: "GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_PassportInfoId",
                table: "Guests",
                newName: "IX_Guests_GenderId");

            migrationBuilder.AddColumn<string>(
                name: "FirtstName",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Genders_GenderId",
                table: "Guests",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Genders_GenderId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "FirtstName",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "Guests",
                newName: "PassportInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_GenderId",
                table: "Guests",
                newName: "IX_Guests_PassportInfoId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_PassportInfo_PassportInfoId",
                table: "Guests",
                column: "PassportInfoId",
                principalTable: "PassportInfo",
                principalColumn: "PassportInfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
