using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_Blagajna_Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReceiptNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Receipts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Receipts");
        }
    }
}
