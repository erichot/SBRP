using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class ProductStock2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InboundStockOrder_SupplierNo_StockNo",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "psi",
                table: "StockTransferOrderDetail");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                schema: "psi",
                table: "StockTransferOrderDetail");

            migrationBuilder.AlterColumn<short>(
                name: "PreOrderQty",
                schema: "psi",
                table: "ProductStock",
                type: "smallint",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "InTransitQty",
                schema: "psi",
                table: "ProductStock",
                type: "smallint",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<int>(
                name: "LogNo",
                schema: "psi",
                table: "ProductStock",
                type: "int",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AlterColumn<int>(
                name: "SellableQty",
                schema: "psi",
                table: "ProductStock",
                type: "int",
                nullable: false,
                computedColumnSql: "[StockQty] - [InTransitQty] - [PreOrderQty]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 11, 4, 5, 815, DateTimeKind.Local).AddTicks(7010));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 11, 4, 5, 815, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 11, 4, 5, 813, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 11, 4, 5, 815, DateTimeKind.Local).AddTicks(9574));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 11, 4, 5, 815, DateTimeKind.Local).AddTicks(3922));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 11, 4, 5, 815, DateTimeKind.Local).AddTicks(9651));

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrder_SupplierNo",
                schema: "psi",
                table: "InboundStockOrder",
                column: "SupplierNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InboundStockOrder_SupplierNo",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.DropColumn(
                name: "LogNo",
                schema: "psi",
                table: "ProductStock");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                schema: "psi",
                table: "StockTransferOrderDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                schema: "psi",
                table: "StockTransferOrderDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "SellableQty",
                schema: "psi",
                table: "ProductStock",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "[StockQty] - [InTransitQty] - [PreOrderQty]");

            migrationBuilder.AlterColumn<short>(
                name: "PreOrderQty",
                schema: "psi",
                table: "ProductStock",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<short>(
                name: "InTransitQty",
                schema: "psi",
                table: "ProductStock",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValueSql: "0");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 1, 15, 47, 33, 760, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 1, 15, 47, 33, 760, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 1, 15, 47, 33, 758, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 1, 15, 47, 33, 760, DateTimeKind.Local).AddTicks(9902));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 1, 15, 47, 33, 760, DateTimeKind.Local).AddTicks(5094));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 1, 15, 47, 33, 760, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrder_SupplierNo_StockNo",
                schema: "psi",
                table: "InboundStockOrder",
                columns: new[] { "SupplierNo", "StockNo" });
        }
    }
}
