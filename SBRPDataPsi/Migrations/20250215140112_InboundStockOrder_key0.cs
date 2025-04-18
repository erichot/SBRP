using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class InboundStockOrder_key0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InboundStockOrderDetail_InboundStockOrder_OrderNo",
                schema: "psi",
                table: "InboundStockOrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InboundStockOrder",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.DropIndex(
                name: "IX_InboundStockOrder_OrderDate",
                schema: "psi",
                table: "InboundStockOrder");

            migrationBuilder.CreateSequence<short>(
                name: "seqStock",
                schema: "psi",
                startValue: 1001L);

            migrationBuilder.AlterColumn<int>(
                name: "LogNo",
                schema: "psi",
                table: "InboundStockOrder",
                type: "int",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "psi",
                table: "InboundStockOrder",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "OrderNo",
                schema: "psi",
                table: "InboundStockOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR psi.seqInboundStockOrder");

            migrationBuilder.RestartSequence(
                name: "seqSupplier",
                schema: "psi",
                startValue: 6001L);

            migrationBuilder.RestartSequence(
                name: "seqStore",
                schema: "psi",
                startValue: 2001L);

            migrationBuilder.RestartSequence(
                name: "seqProductGeneralCategoryItem",
                schema: "psi",
                startValue: 8001L);

            migrationBuilder.RestartSequence(
                name: "seqPermissionGroup",
                schema: "psi",
                startValue: 4001L);

            migrationBuilder.CreateTable(
                name: "ProductStock",
                schema: "psi",
                columns: table => new
                {
                    StockNo = table.Column<short>(type: "smallint", nullable: false),
                    ProductNo = table.Column<int>(type: "int", nullable: false),
                    InTransitQty = table.Column<short>(type: "smallint", nullable: false),
                    PreOrderQty = table.Column<short>(type: "smallint", nullable: false),
                    StockQty = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    SellableQty = table.Column<int>(type: "int", nullable: false),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStock", x => new { x.StockNo, x.ProductNo });
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                schema: "psi",
                columns: table => new
                {
                    StockNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR psi.seqStock"),
                    StockId = table.Column<string>(type: "CHAR(16)", maxLength: 16, nullable: true),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    StockName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StockNameAbbr = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ParentStockNo = table.Column<short>(type: "smallint", nullable: true),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
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
                    table.PrimaryKey("PK_Stock", x => x.StockNo);
                    table.ForeignKey(
                        name: "FK_Stock_Stock_ParentStockNo",
                        column: x => x.ParentStockNo,
                        principalSchema: "psi",
                        principalTable: "Stock",
                        principalColumn: "StockNo");
                });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 22, 1, 8, 777, DateTimeKind.Local).AddTicks(9567));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 22, 1, 8, 778, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 22, 1, 8, 775, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 22, 1, 8, 778, DateTimeKind.Local).AddTicks(2229));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 22, 1, 8, 777, DateTimeKind.Local).AddTicks(7411));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 22, 1, 8, 778, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ParentStockNo",
                schema: "psi",
                table: "Stock",
                column: "ParentStockNo");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_StockId_SIGNo",
                schema: "psi",
                table: "Stock",
                columns: new[] { "StockId", "SIGNo" },
                unique: true,
                filter: "[StockId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStock",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "Stock",
                schema: "psi");

            migrationBuilder.DropSequence(
                name: "seqStock",
                schema: "psi");

            migrationBuilder.AlterColumn<int>(
                name: "OrderNo",
                schema: "psi",
                table: "InboundStockOrder",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR psi.seqInboundStockOrder",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LogNo",
                schema: "psi",
                table: "InboundStockOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "psi",
                table: "InboundStockOrder",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InboundStockOrder",
                schema: "psi",
                table: "InboundStockOrder",
                column: "OrderNo");

            migrationBuilder.RestartSequence(
                name: "seqSupplier",
                schema: "psi",
                startValue: 5001L);

            migrationBuilder.RestartSequence(
                name: "seqStore",
                schema: "psi",
                startValue: 1001L);

            migrationBuilder.RestartSequence(
                name: "seqProductGeneralCategoryItem",
                schema: "psi",
                startValue: 7001L);

            migrationBuilder.RestartSequence(
                name: "seqPermissionGroup",
                schema: "psi",
                startValue: 3001L);

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 18, 47, 24, 388, DateTimeKind.Local).AddTicks(7087));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 18, 47, 24, 388, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 18, 47, 24, 386, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 18, 47, 24, 388, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 18, 47, 24, 388, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 18, 47, 24, 388, DateTimeKind.Local).AddTicks(9641));

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrder_OrderDate",
                schema: "psi",
                table: "InboundStockOrder",
                column: "OrderDate");

            migrationBuilder.AddForeignKey(
                name: "FK_InboundStockOrderDetail_InboundStockOrder_OrderNo",
                schema: "psi",
                table: "InboundStockOrderDetail",
                column: "OrderNo",
                principalSchema: "psi",
                principalTable: "InboundStockOrder",
                principalColumn: "OrderNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
