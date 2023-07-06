using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_Blagajna_Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReceiptItemsReceiptConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "ReceiptItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItems_ReceiptId",
                table: "ReceiptItems",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptItems_Receipts_ReceiptId",
                table: "ReceiptItems",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptItems_Receipts_ReceiptId",
                table: "ReceiptItems");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptItems_ReceiptId",
                table: "ReceiptItems");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "ReceiptItems");
        }
    }
}
