using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class SupplierStockNo_Default : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Store_ParentStoreNo",
                schema: "psi",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Store_ParentStoreNo",
                schema: "psi",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Stock_StockId_SIGNo",
                schema: "psi",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_InboundStockOrder_SupplierNo",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                schema: "psi",
                table: "OperationClassStock");

            migrationBuilder.CreateSequence<short>(
                name: "seqStoreRegion",
                schema: "psi",
                startValue: 12L);

            migrationBuilder.CreateSequence<short>(
                name: "seqSupplierGroup",
                schema: "psi",
                startValue: 101L);

            migrationBuilder.AddColumn<short>(
                name: "StockNo_Default",
                schema: "psi",
                table: "Supplier",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "SupplierGroupNo",
                schema: "psi",
                table: "Supplier",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<bool>(
                name: "IsVirtualStore",
                schema: "psi",
                table: "Store",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<short>(
                name: "StoreRegionNo",
                schema: "psi",
                table: "Store",
                type: "smallint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StockId",
                schema: "psi",
                table: "Stock",
                type: "CHAR(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "CHAR(16)",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StockTransferOrder",
                schema: "psi",
                columns: table => new
                {
                    OrderDateNo = table.Column<short>(type: "smallint", nullable: false),
                    DaySerialNo = table.Column<short>(type: "smallint", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<string>(type: "CHAR(12)", nullable: false),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false, computedColumnSql: "CONVERT([DATE], (DATEADD(day, [OrderDateNo], DATEFROMPARTS(2020,1,1))))"),
                    FromStockNo = table.Column<short>(type: "smallint", nullable: false),
                    ToStockNo = table.Column<short>(type: "smallint", nullable: false),
                    DetailRowCount = table.Column<short>(type: "smallint", nullable: false),
                    DetailSubQty = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogNo = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransferOrder", x => new { x.OrderDateNo, x.DaySerialNo });
                    table.UniqueConstraint("AK_StockTransferOrder_OrderNo", x => x.OrderNo);
                    table.ForeignKey(
                        name: "FK_StockTransferOrder_Stock_FromStockNo",
                        column: x => x.FromStockNo,
                        principalSchema: "psi",
                        principalTable: "Stock",
                        principalColumn: "StockNo");
                    table.ForeignKey(
                        name: "FK_StockTransferOrder_Stock_ToStockNo",
                        column: x => x.ToStockNo,
                        principalSchema: "psi",
                        principalTable: "Stock",
                        principalColumn: "StockNo");
                });

            migrationBuilder.CreateTable(
                name: "StoreRegion",
                schema: "psi",
                columns: table => new
                {
                    StoreRegionNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR psi.seqStoreRegion"),
                    StoreRegionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    StoreRegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentStoreRegionNo = table.Column<short>(type: "smallint", nullable: true),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreRegion", x => x.StoreRegionNo);
                    table.ForeignKey(
                        name: "FK_StoreRegion_StoreRegion_ParentStoreRegionNo",
                        column: x => x.ParentStoreRegionNo,
                        principalSchema: "psi",
                        principalTable: "StoreRegion",
                        principalColumn: "StoreRegionNo");
                });

            migrationBuilder.CreateTable(
                name: "SupplierGroup",
                schema: "psi",
                columns: table => new
                {
                    SupplierGroupId = table.Column<string>(type: "CHAR(16)", nullable: false),
                    SupplierGroupNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR psi.seqSupplierGroup"),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    SupplierGroupName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    SupplierGroupNameAbbr = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    StockNo_Default = table.Column<short>(type: "smallint", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierGroup", x => x.SupplierGroupId);
                    table.ForeignKey(
                        name: "FK_SupplierGroup_Stock_StockNo_Default",
                        column: x => x.StockNo_Default,
                        principalSchema: "psi",
                        principalTable: "Stock",
                        principalColumn: "StockNo");
                });

            migrationBuilder.CreateTable(
                name: "StockTransferOrderDetail",
                schema: "psi",
                columns: table => new
                {
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    ItemNo = table.Column<short>(type: "smallint", nullable: false),
                    ProductNo = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransferOrderDetail", x => new { x.OrderNo, x.ItemNo });
                    table.ForeignKey(
                        name: "FK_StockTransferOrderDetail_Product_ProductNo",
                        column: x => x.ProductNo,
                        principalSchema: "psi",
                        principalTable: "Product",
                        principalColumn: "ProductNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockTransferOrderDetail_StockTransferOrder_OrderNo",
                        column: x => x.OrderNo,
                        principalSchema: "psi",
                        principalTable: "StockTransferOrder",
                        principalColumn: "OrderNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 24, 19, 51, 19, 377, DateTimeKind.Local).AddTicks(7293));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 24, 19, 51, 19, 377, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 24, 19, 51, 19, 375, DateTimeKind.Local).AddTicks(1929));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 24, 19, 51, 19, 377, DateTimeKind.Local).AddTicks(9854));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 24, 19, 51, 19, 377, DateTimeKind.Local).AddTicks(5063));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 24, 19, 51, 19, 377, DateTimeKind.Local).AddTicks(9925));

            migrationBuilder.CreateIndex(
                name: "IX_Store_StoreRegionNo",
                schema: "psi",
                table: "Store",
                column: "StoreRegionNo");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_StockId_SIGNo",
                schema: "psi",
                table: "Stock",
                columns: new[] { "StockId", "SIGNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrder_SupplierNo_StockNo",
                schema: "psi",
                table: "InboundStockOrder",
                columns: new[] { "SupplierNo", "StockNo" });

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferOrder_FromStockNo_ToStockNo",
                schema: "psi",
                table: "StockTransferOrder",
                columns: new[] { "FromStockNo", "ToStockNo" });

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferOrder_OrderId_SIGNo",
                schema: "psi",
                table: "StockTransferOrder",
                columns: new[] { "OrderId", "SIGNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferOrder_OrderNo",
                schema: "psi",
                table: "StockTransferOrder",
                column: "OrderNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferOrder_ToStockNo",
                schema: "psi",
                table: "StockTransferOrder",
                column: "ToStockNo");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferOrderDetail_ProductNo",
                schema: "psi",
                table: "StockTransferOrderDetail",
                column: "ProductNo");

            migrationBuilder.CreateIndex(
                name: "IX_StoreRegion_ParentStoreRegionNo",
                schema: "psi",
                table: "StoreRegion",
                column: "ParentStoreRegionNo");

            migrationBuilder.CreateIndex(
                name: "IX_StoreRegion_StoreRegionId_SIGNo",
                schema: "psi",
                table: "StoreRegion",
                columns: new[] { "StoreRegionId", "SIGNo" },
                unique: true,
                filter: "[StoreRegionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierGroup_StockNo_Default",
                schema: "psi",
                table: "SupplierGroup",
                column: "StockNo_Default");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierGroup_SupplierGroupId_SIGNo",
                schema: "psi",
                table: "SupplierGroup",
                columns: new[] { "SupplierGroupId", "SIGNo" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_StoreRegion_StoreRegionNo",
                schema: "psi",
                table: "Store",
                column: "StoreRegionNo",
                principalSchema: "psi",
                principalTable: "StoreRegion",
                principalColumn: "StoreRegionNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_StoreRegion_StoreRegionNo",
                schema: "psi",
                table: "Store");

            migrationBuilder.DropTable(
                name: "StockTransferOrderDetail",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "StoreRegion",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "SupplierGroup",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "StockTransferOrder",
                schema: "psi");

            migrationBuilder.DropIndex(
                name: "IX_Store_StoreRegionNo",
                schema: "psi",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Stock_StockId_SIGNo",
                schema: "psi",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_InboundStockOrder_SupplierNo_StockNo",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.DropColumn(
                name: "StockNo_Default",
                schema: "psi",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierGroupNo",
                schema: "psi",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsVirtualStore",
                schema: "psi",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "StoreRegionNo",
                schema: "psi",
                table: "Store");

            migrationBuilder.DropSequence(
                name: "seqStoreRegion",
                schema: "psi");

            migrationBuilder.DropSequence(
                name: "seqSupplierGroup",
                schema: "psi");

            migrationBuilder.AlterColumn<string>(
                name: "StockId",
                schema: "psi",
                table: "Stock",
                type: "CHAR(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(16)",
                oldMaxLength: 16);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                schema: "psi",
                table: "OperationClassStock",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

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

            migrationBuilder.CreateIndex(
                name: "IX_Store_ParentStoreNo",
                schema: "psi",
                table: "Store",
                column: "ParentStoreNo");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_StockId_SIGNo",
                schema: "psi",
                table: "Stock",
                columns: new[] { "StockId", "SIGNo" },
                unique: true,
                filter: "[StockId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrder_SupplierNo",
                schema: "psi",
                table: "InboundStockOrder",
                column: "SupplierNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Store_ParentStoreNo",
                schema: "psi",
                table: "Store",
                column: "ParentStoreNo",
                principalSchema: "psi",
                principalTable: "Store",
                principalColumn: "StoreNo");
        }
    }
}
