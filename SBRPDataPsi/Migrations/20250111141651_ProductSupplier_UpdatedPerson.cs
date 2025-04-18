using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class ProductSupplier_UpdatedPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "psi",
                table: "ProductSupplier");

            migrationBuilder.DropColumn(
                name: "DeletedPerson",
                schema: "psi",
                table: "ProductSupplier");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "psi",
                table: "ProductGeneralCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "UpdatedPerson",
                schema: "psi",
                table: "ProductGeneralCategory",
                type: "smallint",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "psi",
                table: "ProductGeneralCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedPerson",
                schema: "psi",
                table: "ProductGeneralCategory");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "psi",
                table: "ProductSupplier",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "DeletedPerson",
                schema: "psi",
                table: "ProductSupplier",
                type: "smallint",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 13, 5, 7, 184, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 13, 5, 7, 184, DateTimeKind.Local).AddTicks(4407));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 13, 5, 7, 181, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 13, 5, 7, 184, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 13, 5, 7, 184, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 13, 5, 7, 184, DateTimeKind.Local).AddTicks(4957));
        }
    }
}
