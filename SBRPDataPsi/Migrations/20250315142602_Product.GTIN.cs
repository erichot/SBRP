using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class ProductGTIN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                schema: "psi",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductIdBySupplier",
                schema: "psi",
                table: "Product",
                newName: "ProductIdFromSupplier");

            migrationBuilder.AddColumn<long>(
                name: "GTIN",
                schema: "psi",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 15, 22, 25, 58, 372, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 15, 22, 25, 58, 373, DateTimeKind.Local).AddTicks(3301));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 15, 22, 25, 58, 370, DateTimeKind.Local).AddTicks(2044));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 15, 22, 25, 58, 373, DateTimeKind.Local).AddTicks(3821));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 15, 22, 25, 58, 372, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 15, 22, 25, 58, 373, DateTimeKind.Local).AddTicks(3899));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GTIN",
                schema: "psi",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductIdFromSupplier",
                schema: "psi",
                table: "Product",
                newName: "ProductIdBySupplier");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                schema: "psi",
                table: "Product",
                type: "CHAR(32)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 15, 18, 48, 53, 594, DateTimeKind.Local).AddTicks(3447));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 15, 18, 48, 53, 594, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 15, 18, 48, 53, 591, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 15, 18, 48, 53, 594, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 15, 18, 48, 53, 594, DateTimeKind.Local).AddTicks(1091));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 15, 18, 48, 53, 594, DateTimeKind.Local).AddTicks(6093));
        }
    }
}
