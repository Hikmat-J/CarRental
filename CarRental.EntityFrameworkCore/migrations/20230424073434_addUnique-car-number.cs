using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class addUniquecarnumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cars_Number",
                table: "Cars",
                column: "Number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_Number",
                table: "Cars");
        }
    }
}
