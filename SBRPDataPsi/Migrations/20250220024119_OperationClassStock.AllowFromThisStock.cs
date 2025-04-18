using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class OperationClassStockAllowFromThisStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisallowFromStock",
                schema: "psi",
                table: "OperationClassStock");

            migrationBuilder.DropColumn(
                name: "DisallowToStock",
                schema: "psi",
                table: "OperationClassStock");

            migrationBuilder.RenameColumn(
                name: "IsToThisStock",
                schema: "psi",
                table: "OperationClassStock",
                newName: "AllowToThisStock");

            migrationBuilder.RenameColumn(
                name: "IsFromThisStock",
                schema: "psi",
                table: "OperationClassStock",
                newName: "AllowFromThisStock");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 10, 41, 15, 747, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 10, 41, 15, 747, DateTimeKind.Local).AddTicks(5380));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 10, 41, 15, 744, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 10, 41, 15, 747, DateTimeKind.Local).AddTicks(5837));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 10, 41, 15, 747, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 10, 41, 15, 747, DateTimeKind.Local).AddTicks(5908));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AllowToThisStock",
                schema: "psi",
                table: "OperationClassStock",
                newName: "IsToThisStock");

            migrationBuilder.RenameColumn(
                name: "AllowFromThisStock",
                schema: "psi",
                table: "OperationClassStock",
                newName: "IsFromThisStock");

            migrationBuilder.AddColumn<bool>(
                name: "DisallowFromStock",
                schema: "psi",
                table: "OperationClassStock",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DisallowToStock",
                schema: "psi",
                table: "OperationClassStock",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 8, 29, 39, 462, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 8, 29, 39, 462, DateTimeKind.Local).AddTicks(4603));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 8, 29, 39, 459, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 8, 29, 39, 462, DateTimeKind.Local).AddTicks(5064));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 8, 29, 39, 462, DateTimeKind.Local).AddTicks(263));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 8, 29, 39, 462, DateTimeKind.Local).AddTicks(5143));
        }
    }
}
