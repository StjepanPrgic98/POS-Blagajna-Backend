using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace POS_Blagajna_Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReceiptItemsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptHeaders_Customers_CustomerId",
                table: "ReceiptHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptHeaders",
                table: "ReceiptHeaders");

            migrationBuilder.RenameTable(
                name: "ReceiptHeaders",
                newName: "Receipts");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptHeaders_CustomerId",
                table: "Receipts",
                newName: "IX_Receipts_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ReceiptItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    DiscountPercentage = table.Column<float>(type: "real", nullable: false),
                    DiscountAmmount = table.Column<float>(type: "real", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiptItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItems_ProductId",
                table: "ReceiptItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Customers_CustomerId",
                table: "Receipts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Customers_CustomerId",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "ReceiptItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.RenameTable(
                name: "Receipts",
                newName: "ReceiptHeaders");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_CustomerId",
                table: "ReceiptHeaders",
                newName: "IX_ReceiptHeaders_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptHeaders",
                table: "ReceiptHeaders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptHeaders_Customers_CustomerId",
                table: "ReceiptHeaders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
