using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class Foreign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "common",
                table: "CompanyContactPerson",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.CreateTable(
                name: "BaseWebPageTemplate",
                schema: "psi",
                columns: table => new
                {
                    PageId = table.Column<string>(type: "CHAR(8)", nullable: false),
                    SubFolder1 = table.Column<string>(type: "VARCHAR(16)", nullable: false),
                    SubFolder2 = table.Column<string>(type: "VARCHAR(24)", nullable: false),
                    PageName = table.Column<string>(type: "VARCHAR(32)", nullable: false),
                    MenuitemNodeId = table.Column<string>(type: "CHAR(8)", nullable: true),
                    ParentPageId = table.Column<string>(type: "CHAR(8)", nullable: true),
                    PageTitle = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PageDescripion = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseWebPageTemplate", x => x.PageId);
                });

            migrationBuilder.CreateTable(
                name: "BaseWebPageSIG",
                schema: "psi",
                columns: table => new
                {
                    PageId = table.Column<string>(type: "CHAR(8)", nullable: false),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false),
                    NodeNo = table.Column<short>(type: "smallint", nullable: true),
                    PageTitle = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PageDescripion = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseWebPageSIG", x => new { x.PageId, x.SIGNo });
                    table.ForeignKey(
                        name: "FK_BaseWebPageSIG_BaseWebPageTemplate_PageId",
                        column: x => x.PageId,
                        principalSchema: "psi",
                        principalTable: "BaseWebPageTemplate",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseWebPageSIG_MenuitemSIG_NodeNo_SIGNo",
                        columns: x => new { x.NodeNo, x.SIGNo },
                        principalSchema: "psi",
                        principalTable: "MenuitemSIG",
                        principalColumns: new[] { "NodeNo", "SIGNo" });
                });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 19, 47, 3, 439, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 19, 47, 3, 439, DateTimeKind.Local).AddTicks(4489));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 19, 47, 3, 435, DateTimeKind.Local).AddTicks(2082));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 19, 47, 3, 439, DateTimeKind.Local).AddTicks(4973));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                columns: new[] { "CreatedDate", "LoginId" },
                values: new object[] { new DateTime(2024, 12, 19, 19, 47, 3, 438, DateTimeKind.Local).AddTicks(9957), "_PREDEF_" });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                columns: new[] { "CreatedDate", "LoginId" },
                values: new object[] { new DateTime(2024, 12, 19, 19, 47, 3, 439, DateTimeKind.Local).AddTicks(5052), "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_BaseWebPageSIG_NodeNo_SIGNo",
                schema: "psi",
                table: "BaseWebPageSIG",
                columns: new[] { "NodeNo", "SIGNo" },
                unique: true,
                filter: "[NodeNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWebPageTemplate_PageId",
                schema: "psi",
                table: "BaseWebPageTemplate",
                column: "PageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseWebPageSIG",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "BaseWebPageTemplate",
                schema: "psi");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "common",
                table: "CompanyContactPerson",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 17, 20, 31, 15, 778, DateTimeKind.Local).AddTicks(4135));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 17, 20, 31, 15, 778, DateTimeKind.Local).AddTicks(6373));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 17, 20, 31, 15, 775, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 17, 20, 31, 15, 778, DateTimeKind.Local).AddTicks(7026));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                columns: new[] { "CreatedDate", "LoginId" },
                values: new object[] { new DateTime(2024, 12, 17, 20, 31, 15, 778, DateTimeKind.Local).AddTicks(1858), "" });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                columns: new[] { "CreatedDate", "LoginId" },
                values: new object[] { new DateTime(2024, 12, 17, 20, 31, 15, 778, DateTimeKind.Local).AddTicks(7099), "" });
        }
    }
}
