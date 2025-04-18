using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPLogPsi.Migrations
{
    /// <inheritdoc />
    public partial class InboundStockOrderDetailLog2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InboundStockOrderLog_SupplierNo",
                schema: "psi",
                table: "InboundStockOrderLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InboundStockOrderDetailLog",
                schema: "psi",
                table: "InboundStockOrderDetailLog");

            migrationBuilder.AlterColumn<short>(
                name: "StockNo",
                schema: "psi",
                table: "InboundStockOrderLog",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InboundStockOrderDetailLog",
                schema: "psi",
                table: "InboundStockOrderDetailLog",
                columns: new[] { "LogNo", "ItemNo" });

            migrationBuilder.CreateTable(
                name: "StockTransferOrderDetailLog",
                schema: "psi",
                columns: table => new
                {
                    ItemNo = table.Column<short>(type: "smallint", nullable: false),
                    LogNo = table.Column<int>(type: "int", nullable: false),
                    LogTypeNo = table.Column<byte>(type: "tinyint", nullable: false),
                    LoginActionNo = table.Column<int>(type: "int", nullable: false),
                    ArchivedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    ProductNo = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransferOrderDetailLog", x => new { x.LogNo, x.ItemNo });
                });

            migrationBuilder.CreateTable(
                name: "StockTransferOrderLog",
                schema: "psi",
                columns: table => new
                {
                    LogNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogTypeNo = table.Column<byte>(type: "tinyint", nullable: false),
                    LoginActionNo = table.Column<int>(type: "int", nullable: false),
                    ArchivedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    OrderDateNo = table.Column<short>(type: "smallint", nullable: false),
                    DaySerialNo = table.Column<short>(type: "smallint", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<string>(type: "CHAR(12)", nullable: false),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FromStockNo = table.Column<short>(type: "smallint", nullable: false),
                    ToStockNo = table.Column<short>(type: "smallint", nullable: false),
                    DetailRowCount = table.Column<short>(type: "smallint", nullable: false),
                    DetailSubQty = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransferOrderLog", x => x.LogNo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferOrderDetailLog_ProductNo",
                schema: "psi",
                table: "StockTransferOrderDetailLog",
                column: "ProductNo");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferOrderLog_FromStockNo_ToStockNo",
                schema: "psi",
                table: "StockTransferOrderLog",
                columns: new[] { "FromStockNo", "ToStockNo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockTransferOrderDetailLog",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "StockTransferOrderLog",
                schema: "psi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InboundStockOrderDetailLog",
                schema: "psi",
                table: "InboundStockOrderDetailLog");

            migrationBuilder.AlterColumn<short>(
                name: "StockNo",
                schema: "psi",
                table: "InboundStockOrderLog",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InboundStockOrderDetailLog",
                schema: "psi",
                table: "InboundStockOrderDetailLog",
                columns: new[] { "LogNo", "OrderNo", "ItemNo" });

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrderLog_SupplierNo",
                schema: "psi",
                table: "InboundStockOrderLog",
                column: "SupplierNo");
        }
    }
}
