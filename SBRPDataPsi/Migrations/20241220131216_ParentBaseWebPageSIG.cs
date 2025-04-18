using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class ParentBaseWebPageSIG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Company_CompanyId",
                schema: "common",
                table: "Company");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 12, 12, 787, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 12, 12, 788, DateTimeKind.Local).AddTicks(1457));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 12, 12, 785, DateTimeKind.Local).AddTicks(3608));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 12, 12, 788, DateTimeKind.Local).AddTicks(1917));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 12, 12, 787, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 12, 12, 788, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId_SIGNo",
                schema: "common",
                table: "User",
                columns: new[] { "UserId", "SIGNo" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Store_StoreId_SIGNo",
                schema: "psi",
                table: "Store",
                columns: new[] { "StoreId", "SIGNo" },
                unique: true,
                filter: "[StoreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonId_SIGNo",
                schema: "common",
                table: "Person",
                columns: new[] { "PersonId", "SIGNo" },
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeId_SIGNo",
                schema: "common",
                table: "Employee",
                columns: new[] { "EmployeeId", "SIGNo" },
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Division_DivisionId_SIGNo",
                schema: "common",
                table: "Division",
                columns: new[] { "DivisionId", "SIGNo" },
                unique: true,
                filter: "[DivisionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepartmentId_SIGNo",
                schema: "common",
                table: "Department",
                columns: new[] { "DepartmentId", "SIGNo" },
                unique: true,
                filter: "[DepartmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyId_SIGNo",
                schema: "common",
                table: "Company",
                columns: new[] { "CompanyId", "SIGNo" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_UserId_SIGNo",
                schema: "common",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Store_StoreId_SIGNo",
                schema: "psi",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Person_PersonId_SIGNo",
                schema: "common",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeId_SIGNo",
                schema: "common",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Division_DivisionId_SIGNo",
                schema: "common",
                table: "Division");

            migrationBuilder.DropIndex(
                name: "IX_Department_DepartmentId_SIGNo",
                schema: "common",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Company_CompanyId_SIGNo",
                schema: "common",
                table: "Company");

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
                name: "IX_Company_CompanyId",
                schema: "common",
                table: "Company",
                column: "CompanyId");
        }
    }
}
