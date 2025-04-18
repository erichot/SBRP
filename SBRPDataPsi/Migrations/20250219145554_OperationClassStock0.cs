using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class OperationClassStock0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLinkToStore",
                schema: "psi",
                table: "Stock",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<short>(
                name: "StockNo",
                schema: "psi",
                table: "InboundStockOrder",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "OrderDate",
                schema: "psi",
                table: "InboundStockOrder",
                type: "date",
                nullable: false,
                computedColumnSql: "CONVERT([DATE], (DATEADD(day, [OrderDateNo], DATEFROMPARTS(2020,1,1))))",
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "OperationClassStock",
                schema: "psi",
                columns: table => new
                {
                    OperationClassNo = table.Column<byte>(type: "tinyint", nullable: false),
                    StockNo = table.Column<short>(type: "smallint", nullable: false),
                    IsFromThisStock = table.Column<bool>(type: "bit", nullable: true),
                    IsToThisStock = table.Column<bool>(type: "bit", nullable: true),
                    OrderPriorityNo = table.Column<short>(type: "smallint", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClassStock", x => new { x.OperationClassNo, x.StockNo });
                    table.ForeignKey(
                        name: "FK_OperationClassStock_Stock_StockNo",
                        column: x => x.StockNo,
                        principalSchema: "psi",
                        principalTable: "Stock",
                        principalColumn: "StockNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 22, 55, 50, 224, DateTimeKind.Local).AddTicks(7015));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 22, 55, 50, 224, DateTimeKind.Local).AddTicks(9860));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 22, 55, 50, 222, DateTimeKind.Local).AddTicks(1788));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 22, 55, 50, 225, DateTimeKind.Local).AddTicks(310));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 22, 55, 50, 224, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 22, 55, 50, 225, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.CreateIndex(
                name: "IX_OperationClassStock_StockNo",
                schema: "psi",
                table: "OperationClassStock",
                column: "StockNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationClassStock",
                schema: "psi");

            migrationBuilder.DropColumn(
                name: "IsLinkToStore",
                schema: "psi",
                table: "Stock");

            migrationBuilder.AlterColumn<short>(
                name: "StockNo",
                schema: "psi",
                table: "InboundStockOrder",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "OrderDate",
                schema: "psi",
                table: "InboundStockOrder",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldComputedColumnSql: "CONVERT([DATE], (DATEADD(day, [OrderDateNo], DATEFROMPARTS(2020,1,1))))");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 21, 34, 16, 244, DateTimeKind.Local).AddTicks(643));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 21, 34, 16, 244, DateTimeKind.Local).AddTicks(3154));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 21, 34, 16, 240, DateTimeKind.Local).AddTicks(5488));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 21, 34, 16, 244, DateTimeKind.Local).AddTicks(3736));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 21, 34, 16, 243, DateTimeKind.Local).AddTicks(8407));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 21, 34, 16, 244, DateTimeKind.Local).AddTicks(3810));
        }
    }
}
