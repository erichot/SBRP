using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class InboundStockOrderLogNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "psi",
                table: "InboundStockOrderDetail");

            migrationBuilder.DropColumn(
                name: "CreatedPerson",
                schema: "psi",
                table: "InboundStockOrderDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "psi",
                table: "InboundStockOrderDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedPerson",
                schema: "psi",
                table: "InboundStockOrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "LogNo",
                schema: "psi",
                table: "InboundStockOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 18, 47, 24, 388, DateTimeKind.Local).AddTicks(7087));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 18, 47, 24, 388, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 18, 47, 24, 386, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 18, 47, 24, 388, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 18, 47, 24, 388, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 18, 47, 24, 388, DateTimeKind.Local).AddTicks(9641));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogNo",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "psi",
                table: "InboundStockOrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<short>(
                name: "CreatedPerson",
                schema: "psi",
                table: "InboundStockOrderDetail",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "psi",
                table: "InboundStockOrderDetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "UpdatedPerson",
                schema: "psi",
                table: "InboundStockOrderDetail",
                type: "smallint",
                nullable: true);

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
        }
    }
}
