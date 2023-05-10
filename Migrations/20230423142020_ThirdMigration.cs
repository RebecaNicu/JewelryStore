using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryStore.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Jewels_JewelId",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Jewels_JewelId",
                table: "Reviews",
                column: "JewelId",
                principalTable: "Jewels",
                principalColumn: "JewelId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Jewels_JewelId",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Jewels_JewelId",
                table: "Reviews",
                column: "JewelId",
                principalTable: "Jewels",
                principalColumn: "JewelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
