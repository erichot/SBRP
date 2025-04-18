using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class UniquqConstraint : Migration
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
                value: new DateTime(2024, 12, 20, 11, 33, 31, 9, DateTimeKind.Local).AddTicks(3947));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 11, 33, 31, 9, DateTimeKind.Local).AddTicks(6087));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 11, 33, 31, 5, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 11, 33, 31, 9, DateTimeKind.Local).AddTicks(6563));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 11, 33, 31, 9, DateTimeKind.Local).AddTicks(1335));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 11, 33, 31, 9, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SupplierId_SIGNo",
                schema: "psi",
                table: "Supplier",
                columns: new[] { "SupplierId", "SIGNo" },
                unique: true,
                filter: "[SupplierId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Supplier_SupplierId_SIGNo",
                schema: "psi",
                table: "Supplier");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 10, 39, 50, 688, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 10, 39, 50, 689, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 10, 39, 50, 686, DateTimeKind.Local).AddTicks(4262));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 10, 39, 50, 689, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 10, 39, 50, 688, DateTimeKind.Local).AddTicks(6170));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 10, 39, 50, 689, DateTimeKind.Local).AddTicks(871));
        }
    }
}
