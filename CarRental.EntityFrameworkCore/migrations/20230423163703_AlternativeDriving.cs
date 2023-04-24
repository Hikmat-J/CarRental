using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AlternativeDriving : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Driver_SubstituteDriverId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_SubstituteDriverId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "SubstituteDriverId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "WithSubstituteDriver",
                table: "Rents");

            migrationBuilder.CreateTable(
                name: "AlternativeDriving",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeDriving", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternativeDriving_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlternativeDriving_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeDriving_CarId",
                table: "AlternativeDriving",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeDriving_DriverId",
                table: "AlternativeDriving",
                column: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlternativeDriving");

            migrationBuilder.AddColumn<int>(
                name: "SubstituteDriverId",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "WithSubstituteDriver",
                table: "Rents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Rents_SubstituteDriverId",
                table: "Rents",
                column: "SubstituteDriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Driver_SubstituteDriverId",
                table: "Rents",
                column: "SubstituteDriverId",
                principalTable: "Driver",
                principalColumn: "Id");
        }
    }
}
