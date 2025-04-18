using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPLogPsi.Migrations
{
    /// <inheritdoc />
    public partial class StockTransferOrderDetailLog2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "psi",
                table: "StockTransferOrderDetailLog");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                schema: "psi",
                table: "StockTransferOrderDetailLog");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                schema: "psi",
                table: "StockTransferOrderDetailLog",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                schema: "psi",
                table: "StockTransferOrderDetailLog",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
