using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPLogPsi.Migrations
{
    /// <inheritdoc />
    public partial class InboundStockOrderDetailLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "psi",
                table: "InboundStockOrderDetailLog");

            migrationBuilder.DropColumn(
                name: "CreatedPerson",
                schema: "psi",
                table: "InboundStockOrderDetailLog");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "psi",
                table: "InboundStockOrderDetailLog");

            migrationBuilder.DropColumn(
                name: "UpdatedPerson",
                schema: "psi",
                table: "InboundStockOrderDetailLog");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "psi",
                table: "InboundStockOrderDetailLog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<short>(
                name: "CreatedPerson",
                schema: "psi",
                table: "InboundStockOrderDetailLog",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "psi",
                table: "InboundStockOrderDetailLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "UpdatedPerson",
                schema: "psi",
                table: "InboundStockOrderDetailLog",
                type: "smallint",
                nullable: true);
        }
    }
}
