using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class InboundStockOrderKey2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "seqInboundStockOrder",
                schema: "psi");

            migrationBuilder.AddColumn<short>(
                name: "OrderDateNo",
                schema: "psi",
                table: "InboundStockOrder",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "DaySerialNo",
                schema: "psi",
                table: "InboundStockOrder",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InboundStockOrder",
                schema: "psi",
                table: "InboundStockOrder",
                columns: new[] { "OrderDateNo", "DaySerialNo" });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 11, 57, 6, 249, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 11, 57, 6, 249, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 11, 57, 6, 246, DateTimeKind.Local).AddTicks(8557));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 11, 57, 6, 249, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 11, 57, 6, 249, DateTimeKind.Local).AddTicks(1880));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 11, 57, 6, 249, DateTimeKind.Local).AddTicks(8163));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InboundStockOrder",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.DropColumn(
                name: "OrderDateNo",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.DropColumn(
                name: "DaySerialNo",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.CreateSequence<int>(
                name: "seqInboundStockOrder",
                schema: "psi",
                startValue: 10000001L);

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 22, 1, 8, 777, DateTimeKind.Local).AddTicks(9567));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 22, 1, 8, 778, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 22, 1, 8, 775, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 22, 1, 8, 778, DateTimeKind.Local).AddTicks(2229));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 22, 1, 8, 777, DateTimeKind.Local).AddTicks(7411));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 22, 1, 8, 778, DateTimeKind.Local).AddTicks(2300));
        }
    }
}
