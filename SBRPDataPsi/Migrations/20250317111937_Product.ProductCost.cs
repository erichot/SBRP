using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class ProductProductCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCost_Product_ProductNo1",
                schema: "psi",
                table: "ProductCost");

            migrationBuilder.DropIndex(
                name: "IX_ProductCost_ProductNo1",
                schema: "psi",
                table: "ProductCost");

            migrationBuilder.DropColumn(
                name: "ProductNo1",
                schema: "psi",
                table: "ProductCost");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 19, 19, 33, 52, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 19, 19, 33, 52, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 19, 19, 33, 49, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 19, 19, 33, 52, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 19, 19, 33, 52, DateTimeKind.Local).AddTicks(2135));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 17, 19, 19, 33, 52, DateTimeKind.Local).AddTicks(6911));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCost_Product_ProductNo",
                schema: "psi",
                table: "ProductCost",
                column: "ProductNo",
                principalSchema: "psi",
                principalTable: "Product",
                principalColumn: "ProductNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCost_Product_ProductNo",
                schema: "psi",
                table: "ProductCost");

            migrationBuilder.AddColumn<int>(
                name: "ProductNo1",
                schema: "psi",
                table: "ProductCost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 16, 16, 38, 15, 596, DateTimeKind.Local).AddTicks(2538));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 16, 16, 38, 15, 596, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 16, 16, 38, 15, 593, DateTimeKind.Local).AddTicks(6867));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 16, 16, 38, 15, 596, DateTimeKind.Local).AddTicks(4969));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 16, 16, 38, 15, 596, DateTimeKind.Local).AddTicks(280));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 16, 16, 38, 15, 596, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.CreateIndex(
                name: "IX_ProductCost_ProductNo1",
                schema: "psi",
                table: "ProductCost",
                column: "ProductNo1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCost_Product_ProductNo1",
                schema: "psi",
                table: "ProductCost",
                column: "ProductNo1",
                principalSchema: "psi",
                principalTable: "Product",
                principalColumn: "ProductNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
