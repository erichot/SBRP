using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class InboundStockOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "seqInboundStockOrder",
                schema: "psi",
                startValue: 10000001L);

            migrationBuilder.CreateTable(
                name: "InboundStockOrder",
                schema: "psi",
                columns: table => new
                {
                    OrderNo = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR psi.seqInboundStockOrder"),
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundStockOrder", x => x.OrderNo);
                    table.ForeignKey(
                        name: "FK_InboundStockOrder_Supplier_SupplierNo",
                        column: x => x.SupplierNo,
                        principalSchema: "psi",
                        principalTable: "Supplier",
                        principalColumn: "SupplierNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InboundStockOrderDetail",
                schema: "psi",
                columns: table => new
                {
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    ItemNo = table.Column<short>(type: "smallint", nullable: false),
                    ProductNo = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundStockOrderDetail", x => new { x.OrderNo, x.ItemNo });
                    table.ForeignKey(
                        name: "FK_InboundStockOrderDetail_InboundStockOrder_OrderNo",
                        column: x => x.OrderNo,
                        principalSchema: "psi",
                        principalTable: "InboundStockOrder",
                        principalColumn: "OrderNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InboundStockOrderDetail_Product_ProductNo",
                        column: x => x.ProductNo,
                        principalSchema: "psi",
                        principalTable: "Product",
                        principalColumn: "ProductNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 26, 17, 3, 58, 110, DateTimeKind.Local).AddTicks(3988));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 26, 17, 3, 58, 110, DateTimeKind.Local).AddTicks(5988));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 26, 17, 3, 58, 107, DateTimeKind.Local).AddTicks(6925));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 26, 17, 3, 58, 110, DateTimeKind.Local).AddTicks(6520));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 26, 17, 3, 58, 110, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 26, 17, 3, 58, 110, DateTimeKind.Local).AddTicks(6590));

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrder_OrderDate",
                schema: "psi",
                table: "InboundStockOrder",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrder_OrderId_SIGNo",
                schema: "psi",
                table: "InboundStockOrder",
                columns: new[] { "OrderId", "SIGNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrder_SupplierNo",
                schema: "psi",
                table: "InboundStockOrder",
                column: "SupplierNo");

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrderDetail_ProductNo",
                schema: "psi",
                table: "InboundStockOrderDetail",
                column: "ProductNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InboundStockOrderDetail",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "InboundStockOrder",
                schema: "psi");

            migrationBuilder.DropSequence(
                name: "seqInboundStockOrder",
                schema: "psi");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 22, 16, 47, 961, DateTimeKind.Local).AddTicks(2396));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 22, 16, 47, 961, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 22, 16, 47, 958, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 22, 16, 47, 961, DateTimeKind.Local).AddTicks(5025));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 22, 16, 47, 960, DateTimeKind.Local).AddTicks(9987));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 11, 22, 16, 47, 961, DateTimeKind.Local).AddTicks(5104));
        }
    }
}
