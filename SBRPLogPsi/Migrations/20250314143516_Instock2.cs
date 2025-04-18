using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPLogPsi.Migrations
{
    /// <inheritdoc />
    public partial class Instock2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailPriceItemNo",
                schema: "psi",
                table: "InboundStockOrderLog");

            migrationBuilder.DropColumn(
                name: "DetailSubAmount",
                schema: "psi",
                table: "InboundStockOrderLog");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "psi",
                table: "InboundStockOrderDetailLog");

            migrationBuilder.RenameColumn(
                name: "DetailSubQty",
                schema: "psi",
                table: "StockTransferOrderLog",
                newName: "TotalQuantity");

            migrationBuilder.RenameColumn(
                name: "DetailRowCount",
                schema: "psi",
                table: "StockTransferOrderLog",
                newName: "UniqueProductCount");

            migrationBuilder.RenameColumn(
                name: "DetailSubQty",
                schema: "psi",
                table: "InboundStockOrderLog",
                newName: "TotalQuantity");

            migrationBuilder.RenameColumn(
                name: "DetailRowCount",
                schema: "psi",
                table: "InboundStockOrderLog",
                newName: "UniqueProductCount");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                schema: "psi",
                table: "InboundStockOrderDetailLog",
                newName: "SubAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitCost",
                schema: "psi",
                table: "InboundStockOrderDetailLog",
                type: "DECIMAL(8,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitCost",
                schema: "psi",
                table: "InboundStockOrderDetailLog");

            migrationBuilder.RenameColumn(
                name: "UniqueProductCount",
                schema: "psi",
                table: "StockTransferOrderLog",
                newName: "DetailRowCount");

            migrationBuilder.RenameColumn(
                name: "TotalQuantity",
                schema: "psi",
                table: "StockTransferOrderLog",
                newName: "DetailSubQty");

            migrationBuilder.RenameColumn(
                name: "UniqueProductCount",
                schema: "psi",
                table: "InboundStockOrderLog",
                newName: "DetailRowCount");

            migrationBuilder.RenameColumn(
                name: "TotalQuantity",
                schema: "psi",
                table: "InboundStockOrderLog",
                newName: "DetailSubQty");

            migrationBuilder.RenameColumn(
                name: "SubAmount",
                schema: "psi",
                table: "InboundStockOrderDetailLog",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<byte>(
                name: "DetailPriceItemNo",
                schema: "psi",
                table: "InboundStockOrderLog",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<decimal>(
                name: "DetailSubAmount",
                schema: "psi",
                table: "InboundStockOrderLog",
                type: "DECIMAL(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                schema: "psi",
                table: "InboundStockOrderDetailLog",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
