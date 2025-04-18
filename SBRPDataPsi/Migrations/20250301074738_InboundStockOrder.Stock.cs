using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class InboundStockOrderStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_InboundStockOrder_StockNo",
                schema: "psi",
                table: "InboundStockOrder",
                column: "StockNo");

            migrationBuilder.AddForeignKey(
                name: "FK_InboundStockOrder_Stock_StockNo",
                schema: "psi",
                table: "InboundStockOrder",
                column: "StockNo",
                principalSchema: "psi",
                principalTable: "Stock",
                principalColumn: "StockNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InboundStockOrder_Stock_StockNo",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.DropIndex(
                name: "IX_InboundStockOrder_StockNo",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 24, 19, 51, 19, 377, DateTimeKind.Local).AddTicks(7293));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 24, 19, 51, 19, 377, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 24, 19, 51, 19, 375, DateTimeKind.Local).AddTicks(1929));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 24, 19, 51, 19, 377, DateTimeKind.Local).AddTicks(9854));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 24, 19, 51, 19, 377, DateTimeKind.Local).AddTicks(5063));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 24, 19, 51, 19, 377, DateTimeKind.Local).AddTicks(9925));
        }
    }
}
