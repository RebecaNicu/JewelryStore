using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryStore.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jewels_Categories_CategoryId",
                table: "Jewels");

            migrationBuilder.AddForeignKey(
                name: "FK_Jewels_Categories_CategoryId",
                table: "Jewels",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jewels_Categories_CategoryId",
                table: "Jewels");

            migrationBuilder.AddForeignKey(
                name: "FK_Jewels_Categories_CategoryId",
                table: "Jewels",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }
    }
}
