using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_Blagajna_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ReceiptEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "Receipts",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_EmployeeId",
                table: "Receipts",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_EmployeeId",
                table: "Receipts",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_EmployeeId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_EmployeeId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Receipts");
        }
    }
}
