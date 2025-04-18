using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class ParentSIGPageNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseWebPageSIG",
                schema: "psi",
                table: "BaseWebPageSIG");

            migrationBuilder.CreateSequence<short>(
                name: "seqBaseWebPageSIG",
                schema: "psi",
                startValue: 501L);

            migrationBuilder.AddColumn<short>(
                name: "SIGPageNo",
                schema: "psi",
                table: "BaseWebPageSIG",
                type: "smallint",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR psi.seqBaseWebPageSIG");

            migrationBuilder.AddColumn<short>(
                name: "ParentSIGPageNo",
                schema: "psi",
                table: "BaseWebPageSIG",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseWebPageSIG",
                schema: "psi",
                table: "BaseWebPageSIG",
                column: "SIGPageNo");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 25, 42, 436, DateTimeKind.Local).AddTicks(331));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 25, 42, 436, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 25, 42, 433, DateTimeKind.Local).AddTicks(5444));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 25, 42, 436, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 25, 42, 435, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 25, 42, 436, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.CreateIndex(
                name: "IX_BaseWebPageSIG_PageId_SIGNo",
                schema: "psi",
                table: "BaseWebPageSIG",
                columns: new[] { "PageId", "SIGNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseWebPageSIG_ParentSIGPageNo",
                schema: "psi",
                table: "BaseWebPageSIG",
                column: "ParentSIGPageNo");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseWebPageSIG_BaseWebPageSIG_ParentSIGPageNo",
                schema: "psi",
                table: "BaseWebPageSIG",
                column: "ParentSIGPageNo",
                principalSchema: "psi",
                principalTable: "BaseWebPageSIG",
                principalColumn: "SIGPageNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseWebPageSIG_BaseWebPageSIG_ParentSIGPageNo",
                schema: "psi",
                table: "BaseWebPageSIG");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseWebPageSIG",
                schema: "psi",
                table: "BaseWebPageSIG");

            migrationBuilder.DropIndex(
                name: "IX_BaseWebPageSIG_PageId_SIGNo",
                schema: "psi",
                table: "BaseWebPageSIG");

            migrationBuilder.DropIndex(
                name: "IX_BaseWebPageSIG_ParentSIGPageNo",
                schema: "psi",
                table: "BaseWebPageSIG");

            migrationBuilder.DropColumn(
                name: "SIGPageNo",
                schema: "psi",
                table: "BaseWebPageSIG");

            migrationBuilder.DropColumn(
                name: "ParentSIGPageNo",
                schema: "psi",
                table: "BaseWebPageSIG");

            migrationBuilder.DropSequence(
                name: "seqBaseWebPageSIG",
                schema: "psi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseWebPageSIG",
                schema: "psi",
                table: "BaseWebPageSIG",
                columns: new[] { "PageId", "SIGNo" });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 12, 12, 787, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 12, 12, 788, DateTimeKind.Local).AddTicks(1457));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 12, 12, 785, DateTimeKind.Local).AddTicks(3608));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 12, 12, 788, DateTimeKind.Local).AddTicks(1917));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 12, 12, 787, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 21, 12, 12, 788, DateTimeKind.Local).AddTicks(1993));
        }
    }
}
