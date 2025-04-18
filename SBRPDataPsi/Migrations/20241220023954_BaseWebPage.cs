using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class BaseWebPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BaseWebPageSIG_NodeNo_SIGNo",
                schema: "psi",
                table: "BaseWebPageSIG");

            migrationBuilder.CreateSequence<short>(
                name: "seqStore",
                schema: "psi",
                startValue: 1001L);

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "psi",
                columns: table => new
                {
                    StoreNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR psi.seqStore"),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    StoreId = table.Column<string>(type: "CHAR(16)", maxLength: 16, nullable: true),
                    StoreName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StoreNameAbbr = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CompanyNo = table.Column<short>(type: "smallint", nullable: true),
                    ParentStoreNo = table.Column<short>(type: "smallint", nullable: true),
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
                    table.PrimaryKey("PK_Store", x => x.StoreNo);
                    table.ForeignKey(
                        name: "FK_Store_Company_CompanyNo",
                        column: x => x.CompanyNo,
                        principalSchema: "common",
                        principalTable: "Company",
                        principalColumn: "CompanyNo");
                    table.ForeignKey(
                        name: "FK_Store_Store_ParentStoreNo",
                        column: x => x.ParentStoreNo,
                        principalSchema: "psi",
                        principalTable: "Store",
                        principalColumn: "StoreNo");
                });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 10, 39, 50, 688, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 10, 39, 50, 689, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 10, 39, 50, 686, DateTimeKind.Local).AddTicks(4262));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 10, 39, 50, 689, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 10, 39, 50, 688, DateTimeKind.Local).AddTicks(6170));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 20, 10, 39, 50, 689, DateTimeKind.Local).AddTicks(871));

            migrationBuilder.CreateIndex(
                name: "IX_BaseWebPageSIG_NodeNo_SIGNo",
                schema: "psi",
                table: "BaseWebPageSIG",
                columns: new[] { "NodeNo", "SIGNo" });

            migrationBuilder.CreateIndex(
                name: "IX_Store_CompanyNo",
                schema: "psi",
                table: "Store",
                column: "CompanyNo");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ParentStoreNo",
                schema: "psi",
                table: "Store",
                column: "ParentStoreNo");

            migrationBuilder.CreateIndex(
                name: "IX_Store_StoreId",
                schema: "psi",
                table: "Store",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Store",
                schema: "psi");

            migrationBuilder.DropIndex(
                name: "IX_BaseWebPageSIG_NodeNo_SIGNo",
                schema: "psi",
                table: "BaseWebPageSIG");

            migrationBuilder.DropSequence(
                name: "seqStore",
                schema: "psi");

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
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 19, 47, 3, 438, DateTimeKind.Local).AddTicks(9957));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 19, 47, 3, 439, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.CreateIndex(
                name: "IX_BaseWebPageSIG_NodeNo_SIGNo",
                schema: "psi",
                table: "BaseWebPageSIG",
                columns: new[] { "NodeNo", "SIGNo" },
                unique: true,
                filter: "[NodeNo] IS NOT NULL");
        }
    }
}
