using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class Member_fix4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_Member_MemberId_SIGNo",
            //    schema: "psi",
            //    table: "Member");

            migrationBuilder.AlterColumn<int>(
                name: "MemberNo",
                schema: "psi",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR psi.seqMember",
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.AlterColumn<string>(
            //    name: "MemberId",
            //    schema: "psi",
            //    table: "Member",
            //    type: "CHAR(36)",
            //    maxLength: 36,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "CHAR(36)",
            //    oldMaxLength: 36);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                schema: "psi",
                table: "Member",
                column: "MemberNo");

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

            //migrationBuilder.CreateIndex(
            //    name: "IX_Member_MemberId_SIGNo",
            //    schema: "psi",
            //    table: "Member",
            //    columns: new[] { "MemberId", "SIGNo" },
            //    unique: true,
            //    filter: "[MemberId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                schema: "psi",
                table: "Member");

            //migrationBuilder.DropIndex(
            //    name: "IX_Member_MemberId_SIGNo",
            //    schema: "psi",
            //    table: "Member");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                schema: "psi",
                table: "Member",
                type: "CHAR(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "CHAR(36)",
                oldMaxLength: 36,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberNo",
                schema: "psi",
                table: "Member",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR psi.seqMember");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 7, 23, 857, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 7, 23, 857, DateTimeKind.Local).AddTicks(6732));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 7, 23, 854, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 7, 23, 857, DateTimeKind.Local).AddTicks(7217));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 7, 23, 857, DateTimeKind.Local).AddTicks(2144));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 13, 7, 23, 857, DateTimeKind.Local).AddTicks(7287));

            //migrationBuilder.CreateIndex(
            //    name: "IX_Member_MemberId_SIGNo",
            //    schema: "psi",
            //    table: "Member",
            //    columns: new[] { "MemberId", "SIGNo" },
            //    unique: true);
        }
    }
}
