using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class Product_ProductGeneralCategoryItem : Migration
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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGeneralCategory_ProductGeneralCategoryItem_PGCItemNo",
                schema: "psi",
                table: "ProductGeneralCategory",
                column: "PGCItemNo",
                principalSchema: "psi",
                principalTable: "ProductGeneralCategoryItem",
                principalColumn: "PGCItemNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGeneralCategory_ProductGeneralCategoryItem_PGCItemNo",
                schema: "psi",
                table: "ProductGeneralCategory");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 12, 58, 20, 873, DateTimeKind.Local).AddTicks(3273));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 12, 58, 20, 873, DateTimeKind.Local).AddTicks(5424));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 12, 58, 20, 870, DateTimeKind.Local).AddTicks(7393));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 12, 58, 20, 873, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 12, 58, 20, 873, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 12, 58, 20, 873, DateTimeKind.Local).AddTicks(5963));
        }
    }
}
