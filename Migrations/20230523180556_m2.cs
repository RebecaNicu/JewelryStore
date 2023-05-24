using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryStore.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlJewelPhoto",
                table: "Jewels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlJewelPhoto",
                table: "Jewels");
        }
    }
}
