using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class InboundStockOrderKey6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderNo",
                schema: "psi",
                table: "InboundStockOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "(CAST([OrderDateNo] AS INT) * 65536 + CAST([DaySerialNo] AS INT)) PERSISTED NOT NULL");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_InboundStockOrder_OrderNo",
                schema: "psi",
                table: "InboundStockOrder",
                column: "OrderNo");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 21, 34, 16, 244, DateTimeKind.Local).AddTicks(643));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 21, 34, 16, 244, DateTimeKind.Local).AddTicks(3154));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 21, 34, 16, 240, DateTimeKind.Local).AddTicks(5488));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 21, 34, 16, 244, DateTimeKind.Local).AddTicks(3736));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 21, 34, 16, 243, DateTimeKind.Local).AddTicks(8407));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 21, 34, 16, 244, DateTimeKind.Local).AddTicks(3810));

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrder_OrderNo",
                schema: "psi",
                table: "InboundStockOrder",
                column: "OrderNo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InboundStockOrderDetail_InboundStockOrder_OrderNo",
                schema: "psi",
                table: "InboundStockOrderDetail",
                column: "OrderNo",
                principalSchema: "psi",
                principalTable: "InboundStockOrder",
                principalColumn: "OrderNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InboundStockOrderDetail_InboundStockOrder_OrderNo",
                schema: "psi",
                table: "InboundStockOrderDetail");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_InboundStockOrder_OrderNo",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.DropIndex(
                name: "IX_InboundStockOrder_OrderNo",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.AlterColumn<int>(
                name: "OrderNo",
                schema: "psi",
                table: "InboundStockOrder",
                type: "int",
                nullable: false,
                computedColumnSql: "(CAST([OrderDateNo] AS INT) * 65536 + CAST([DaySerialNo] AS INT)) PERSISTED NOT NULL",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 20, 13, 25, 832, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 20, 13, 25, 832, DateTimeKind.Local).AddTicks(9230));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 20, 13, 25, 830, DateTimeKind.Local).AddTicks(1985));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 20, 13, 25, 832, DateTimeKind.Local).AddTicks(9687));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 20, 13, 25, 832, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 20, 13, 25, 832, DateTimeKind.Local).AddTicks(9760));
        }
    }
}
