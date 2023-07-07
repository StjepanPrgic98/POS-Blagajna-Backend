using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_Blagajna_Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductCodeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Products");
        }
    }
}
