using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class ProductPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "psi",
                table: "InboundStockOrderDetail");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                schema: "psi",
                table: "InboundStockOrderDetail");

            migrationBuilder.DropColumn(
                name: "DetailPriceItemNo",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.DropColumn(
                name: "DetailSubAmount",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.DropColumn(
                name: "DetailSubQty",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.RenameColumn(
                name: "DetailSubQty",
                schema: "psi",
                table: "StockTransferOrder",
                newName: "TotalQuantity");

            migrationBuilder.RenameColumn(
                name: "DetailRowCount",
                schema: "psi",
                table: "StockTransferOrder",
                newName: "UniqueProductCount");

            migrationBuilder.RenameColumn(
                name: "DetailRowCount",
                schema: "psi",
                table: "InboundStockOrder",
                newName: "UniqueProductCount");

            migrationBuilder.AddColumn<byte>(
                name: "CurrencyNo",
                schema: "psi",
                table: "Supplier",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                schema: "psi",
                table: "Product",
                type: "CHAR(32)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductIdBySupplier",
                schema: "psi",
                table: "Product",
                type: "CHAR(32)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitCost",
                schema: "psi",
                table: "InboundStockOrderDetail",
                type: "DECIMAL(8,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                schema: "psi",
                table: "InboundStockOrder",
                type: "DECIMAL(10,2)",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,2)");

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                schema: "psi",
                table: "InboundStockOrder",
                type: "int",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<decimal>(
                name: "SubAmount",
                schema: "psi",
                table: "InboundStockOrderDetail",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[Quantity] * [UnitCost]");

            migrationBuilder.CreateTable(
                name: "ProductPrice",
                schema: "psi",
                columns: table => new
                {
                    ProductNo = table.Column<int>(type: "int", nullable: false),
                    PriceNo = table.Column<byte>(type: "tinyint", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrice", x => new { x.ProductNo, x.PriceNo });
                    table.ForeignKey(
                        name: "FK_ProductPrice_Product_ProductNo",
                        column: x => x.ProductNo,
                        principalSchema: "psi",
                        principalTable: "Product",
                        principalColumn: "ProductNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPriceDefinition",
                schema: "psi",
                columns: table => new
                {
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false),
                    PriceNo = table.Column<byte>(type: "tinyint", nullable: false),
                    PriceDefinitionName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ParentPriceNo = table.Column<byte>(type: "tinyint", nullable: true),
                    PercentageToParent = table.Column<decimal>(type: "DECIMAL(5,3)", nullable: false),
                    RoundUpDigitNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    IsInitial = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPriceDefinition", x => new { x.SIGNo, x.PriceNo });
                });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 14, 22, 32, 23, 997, DateTimeKind.Local).AddTicks(58));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 14, 22, 32, 23, 997, DateTimeKind.Local).AddTicks(2161));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 14, 22, 32, 23, 994, DateTimeKind.Local).AddTicks(5089));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 14, 22, 32, 23, 997, DateTimeKind.Local).AddTicks(2639));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 14, 22, 32, 23, 996, DateTimeKind.Local).AddTicks(7879));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 14, 22, 32, 23, 997, DateTimeKind.Local).AddTicks(2713));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPrice",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "ProductPriceDefinition",
                schema: "psi");

            migrationBuilder.DropColumn(
                name: "SubAmount",
                schema: "psi",
                table: "InboundStockOrderDetail");

            migrationBuilder.DropColumn(
                name: "CurrencyNo",
                schema: "psi",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Barcode",
                schema: "psi",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductIdBySupplier",
                schema: "psi",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UnitCost",
                schema: "psi",
                table: "InboundStockOrderDetail");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.RenameColumn(
                name: "UniqueProductCount",
                schema: "psi",
                table: "StockTransferOrder",
                newName: "DetailRowCount");

            migrationBuilder.RenameColumn(
                name: "TotalQuantity",
                schema: "psi",
                table: "StockTransferOrder",
                newName: "DetailSubQty");

            migrationBuilder.RenameColumn(
                name: "UniqueProductCount",
                schema: "psi",
                table: "InboundStockOrder",
                newName: "DetailRowCount");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                schema: "psi",
                table: "InboundStockOrderDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                schema: "psi",
                table: "InboundStockOrderDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                schema: "psi",
                table: "InboundStockOrder",
                type: "DECIMAL(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,2)",
                oldDefaultValueSql: "0");

            migrationBuilder.AddColumn<byte>(
                name: "DetailPriceItemNo",
                schema: "psi",
                table: "InboundStockOrder",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<decimal>(
                name: "DetailSubAmount",
                schema: "psi",
                table: "InboundStockOrder",
                type: "DECIMAL(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DetailSubQty",
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
                value: new DateTime(2025, 3, 6, 11, 4, 5, 815, DateTimeKind.Local).AddTicks(7010));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 11, 4, 5, 815, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 11, 4, 5, 813, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 11, 4, 5, 815, DateTimeKind.Local).AddTicks(9574));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 11, 4, 5, 815, DateTimeKind.Local).AddTicks(3922));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 11, 4, 5, 815, DateTimeKind.Local).AddTicks(9651));
        }
    }
}
