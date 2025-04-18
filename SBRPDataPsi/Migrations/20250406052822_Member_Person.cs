using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class Member_Person : Migration
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
                value: new DateTime(2025, 4, 6, 13, 28, 18, 544, DateTimeKind.Local).AddTicks(3683));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 28, 18, 544, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 28, 18, 541, DateTimeKind.Local).AddTicks(4708));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 28, 18, 544, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 28, 18, 544, DateTimeKind.Local).AddTicks(1255));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 28, 18, 544, DateTimeKind.Local).AddTicks(6336));

            migrationBuilder.CreateIndex(
                name: "IX_Member_PersonNo",
                schema: "psi",
                table: "Member",
                column: "PersonNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Person_PersonNo",
                schema: "psi",
                table: "Member",
                column: "PersonNo",
                principalSchema: "common",
                principalTable: "Person",
                principalColumn: "PersonNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Person_PersonNo",
                schema: "psi",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_PersonNo",
                schema: "psi",
                table: "Member");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 22, 13, 841, DateTimeKind.Local).AddTicks(494));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 22, 13, 841, DateTimeKind.Local).AddTicks(2632));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 22, 13, 838, DateTimeKind.Local).AddTicks(5572));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 22, 13, 841, DateTimeKind.Local).AddTicks(3127));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 22, 13, 840, DateTimeKind.Local).AddTicks(7982));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 22, 13, 841, DateTimeKind.Local).AddTicks(3211));
        }
    }
}
