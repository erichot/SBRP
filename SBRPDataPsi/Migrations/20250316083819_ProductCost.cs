using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class ProductCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCost",
                schema: "psi",
                columns: table => new
                {
                    ProductNo = table.Column<int>(type: "int", nullable: false),
                    CostNo = table.Column<byte>(type: "tinyint", nullable: false),
                    UnitCost = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    ProductNo1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCost", x => new { x.ProductNo, x.CostNo });
                    table.ForeignKey(
                        name: "FK_ProductCost_Product_ProductNo1",
                        column: x => x.ProductNo1,
                        principalSchema: "psi",
                        principalTable: "Product",
                        principalColumn: "ProductNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCostDefinition",
                schema: "psi",
                columns: table => new
                {
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false),
                    CostNo = table.Column<byte>(type: "tinyint", nullable: false),
                    CostDefinitionName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCostDefinition", x => new { x.SIGNo, x.CostNo });
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCost",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "ProductCostDefinition",
                schema: "psi");

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
    }
}
