using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class substituteDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Driver_SubstituteDriverId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_SubstituteDriverId",
                table: "Rents");
        }
    }
}
