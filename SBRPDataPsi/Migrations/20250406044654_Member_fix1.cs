using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class Member_fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Person_PersonNo1",
                schema: "psi",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                schema: "psi",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_PersonNo1",
                schema: "psi",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "PersonNo1",
                schema: "psi",
                table: "Member");

            migrationBuilder.CreateSequence<int>(
                name: "seqMember",
                schema: "psi",
                startValue: 300001L);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                schema: "psi",
                table: "Member",
                column: "MemberId");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 12, 46, 50, 601, DateTimeKind.Local).AddTicks(3863));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 12, 46, 50, 601, DateTimeKind.Local).AddTicks(6047));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 12, 46, 50, 598, DateTimeKind.Local).AddTicks(2909));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 12, 46, 50, 601, DateTimeKind.Local).AddTicks(6592));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 12, 46, 50, 600, DateTimeKind.Local).AddTicks(9616));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 12, 46, 50, 601, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.CreateIndex(
                name: "IX_Member_MemberId_SIGNo",
                schema: "psi",
                table: "Member",
                columns: new[] { "MemberId", "SIGNo" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                schema: "psi",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_MemberId_SIGNo",
                schema: "psi",
                table: "Member");

            migrationBuilder.DropSequence(
                name: "seqMember",
                schema: "psi");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                schema: "psi",
                table: "Member",
                type: "CHAR(36)",
                maxLength: 36,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(36)",
                oldMaxLength: 36);

            migrationBuilder.AddColumn<int>(
                name: "PersonNo1",
                schema: "psi",
                table: "Member",
                type: "int",
                nullable: true);

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
                value: new DateTime(2025, 4, 6, 11, 50, 59, 420, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 11, 50, 59, 420, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 11, 50, 59, 413, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 11, 50, 59, 420, DateTimeKind.Local).AddTicks(6973));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 11, 50, 59, 419, DateTimeKind.Local).AddTicks(1762));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 6, 11, 50, 59, 420, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.CreateIndex(
                name: "IX_Member_PersonNo1",
                schema: "psi",
                table: "Member",
                column: "PersonNo1");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Person_PersonNo1",
                schema: "psi",
                table: "Member",
                column: "PersonNo1",
                principalSchema: "common",
                principalTable: "Person",
                principalColumn: "PersonNo");
        }
    }
}
