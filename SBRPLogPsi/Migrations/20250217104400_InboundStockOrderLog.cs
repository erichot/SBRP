using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPLogPsi.Migrations
{
    /// <inheritdoc />
    public partial class InboundStockOrderLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InboundStockOrderLog_OrderDate",
                schema: "psi",
                table: "InboundStockOrderLog");

            migrationBuilder.AddColumn<short>(
                name: "DaySerialNo",
                schema: "psi",
                table: "InboundStockOrderLog",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "OrderDateNo",
                schema: "psi",
                table: "InboundStockOrderLog",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaySerialNo",
                schema: "psi",
                table: "InboundStockOrderLog");

            migrationBuilder.DropColumn(
                name: "OrderDateNo",
                schema: "psi",
                table: "InboundStockOrderLog");

            migrationBuilder.CreateIndex(
                name: "IX_InboundStockOrderLog_OrderDate",
                schema: "psi",
                table: "InboundStockOrderLog",
                column: "OrderDate");
        }
    }
}
