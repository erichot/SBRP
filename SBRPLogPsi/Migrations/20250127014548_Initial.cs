using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPLogPsi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "psi");

            migrationBuilder.CreateTable(
                name: "InboundStockOrderDetailLog",
                schema: "psi",
                columns: table => new
                {
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    ItemNo = table.Column<short>(type: "smallint", nullable: false),
                    LogNo = table.Column<int>(type: "int", nullable: false),
                    LogTypeNo = table.Column<byte>(type: "tinyint", nullable: false),
                    LoginActionNo = table.Column<int>(type: "int", nullable: false),
                    ArchivedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ProductNo = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundStockOrderDetailLog", x => new { x.LogNo, x.OrderNo, x.ItemNo });
                });

            migrationBuilder.CreateTable(
                name: "InboundStockOrderLog",
                schema: "psi",
                columns: table => new
                {
                    LogNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogTypeNo = table.Column<byte>(type: "tinyint", nullable: false),
                    LoginActionNo = table.Column<int>(type: "int", nullable: false),
                    ArchivedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<string>(type: "CHAR(12)", nullable: false),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false),
                    SupplierNo = table.Column<short>(type: "smallint", nullable: false),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    StockNo = table.Column<short>(type: "smallint", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    DetailPriceItemNo = table.Column<byte>(type: "tinyint", nullable: false),
                    DetailRowCount = table.Column<short>(type: "smallint", nullable: false),
                    DetailSubQty = table.Column<int>(type: "int", nullable: false),
                    DetailSubAmount = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
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
                    table.PrimaryKey("PK_InboundStockOrderLog", x => x.LogNo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrderDetailLog_ProductNo",
                schema: "psi",
                table: "InboundStockOrderDetailLog",
                column: "ProductNo");

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrderLog_OrderDate",
                schema: "psi",
                table: "InboundStockOrderLog",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrderLog_SupplierNo",
                schema: "psi",
                table: "InboundStockOrderLog",
                column: "SupplierNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InboundStockOrderDetailLog",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "InboundStockOrderLog",
                schema: "psi");
        }
    }
}
