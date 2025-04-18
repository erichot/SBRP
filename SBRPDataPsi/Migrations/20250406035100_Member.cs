using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class Member : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GTIN",
                schema: "psi",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                schema: "common",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ApprovedPerson",
                schema: "common",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                schema: "common",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IsSubmitted",
                schema: "common",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "SubmittedDate",
                schema: "common",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "SubmittedPerson",
                schema: "common",
                table: "Person");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisabled",
                schema: "psi",
                table: "ProductSupplier",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "psi",
                table: "ProductSupplier",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                schema: "psi",
                table: "ProductSupplier",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "psi",
                table: "ProductSupplier",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "OrderNo",
                schema: "psi",
                table: "ProductStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PriceDefinitionDisplayName",
                schema: "psi",
                table: "ProductPriceDefinition",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "psi",
                table: "ProductGeneralCategoryItem",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "psi",
                table: "ProductGeneralCategoryDefinition",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsParentalProduct",
                schema: "psi",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotForOrderProcessing",
                schema: "psi",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "psi",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                schema: "psi",
                table: "Product",
                type: "CHAR(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                schema: "common",
                table: "Person",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(48)",
                oldMaxLength: 48,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonName",
                schema: "common",
                table: "Person",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthday",
                schema: "common",
                table: "Person",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Sex",
                schema: "common",
                table: "Person",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Member",
                schema: "psi",
                columns: table => new
                {
                    MemberNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<string>(type: "CHAR(36)", maxLength: 36, nullable: true),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    PersonNo = table.Column<int>(type: "int", nullable: false),
                    ProductPriceNo = table.Column<byte>(type: "tinyint", nullable: false),
                    Birthday_Month = table.Column<byte>(type: "tinyint", nullable: true),
                    Birthday_Day = table.Column<byte>(type: "tinyint", nullable: true),
                    Birthday_MonthDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonNo1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberNo);
                    table.ForeignKey(
                        name: "FK_Member_Person_PersonNo1",
                        column: x => x.PersonNo1,
                        principalSchema: "common",
                        principalTable: "Person",
                        principalColumn: "PersonNo");
                });

            migrationBuilder.CreateTable(
                name: "PersonContactPhone",
                schema: "common",
                columns: table => new
                {
                    PersonNo = table.Column<int>(type: "int", nullable: false),
                    ItemNo = table.Column<byte>(type: "tinyint", nullable: false),
                    ContactPhoneType = table.Column<byte>(type: "tinyint", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContactPhone", x => new { x.PersonNo, x.ItemNo });
                    table.ForeignKey(
                        name: "FK_PersonContactPhone_Person_PersonNo",
                        column: x => x.PersonNo,
                        principalSchema: "common",
                        principalTable: "Person",
                        principalColumn: "PersonNo",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Birthday", "CreatedDate", "Sex" },
                values: new object[] { null, new DateTime(2025, 4, 6, 11, 50, 59, 413, DateTimeKind.Local).AddTicks(5057), (byte)0 });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                columns: new[] { "Birthday", "CreatedDate", "Sex" },
                values: new object[] { null, new DateTime(2025, 4, 6, 11, 50, 59, 420, DateTimeKind.Local).AddTicks(6973), (byte)0 });

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
                name: "IX_Product_Barcode",
                schema: "psi",
                table: "Product",
                column: "Barcode");

            migrationBuilder.CreateIndex(
                name: "IX_Member_PersonNo1",
                schema: "psi",
                table: "Member",
                column: "PersonNo1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "PersonContactPhone",
                schema: "common");

            migrationBuilder.DropIndex(
                name: "IX_Product_Barcode",
                schema: "psi",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderNo",
                schema: "psi",
                table: "ProductStock");

            migrationBuilder.DropColumn(
                name: "PriceDefinitionDisplayName",
                schema: "psi",
                table: "ProductPriceDefinition");

            migrationBuilder.DropColumn(
                name: "Barcode",
                schema: "psi",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Birthday",
                schema: "common",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Sex",
                schema: "common",
                table: "Person");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisabled",
                schema: "psi",
                table: "ProductSupplier",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "psi",
                table: "ProductSupplier",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                schema: "psi",
                table: "ProductSupplier",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "psi",
                table: "ProductSupplier",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "psi",
                table: "ProductGeneralCategoryItem",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "psi",
                table: "ProductGeneralCategoryDefinition",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IsParentalProduct",
                schema: "psi",
                table: "Product",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotForOrderProcessing",
                schema: "psi",
                table: "Product",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "psi",
                table: "Product",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AddColumn<long>(
                name: "GTIN",
                schema: "psi",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                schema: "common",
                table: "Person",
                type: "nvarchar(48)",
                maxLength: 48,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldMaxLength: 36,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonName",
                schema: "common",
                table: "Person",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                schema: "common",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "ApprovedPerson",
                schema: "common",
                table: "Person",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                schema: "common",
                table: "Person",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmitted",
                schema: "common",
                table: "Person",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedDate",
                schema: "common",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "SubmittedPerson",
                schema: "common",
                table: "Person",
                type: "smallint",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 26, 19, 42, 15, 398, DateTimeKind.Local).AddTicks(9863));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 26, 19, 42, 15, 399, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                columns: new[] { "ApprovedDate", "ApprovedPerson", "CreatedDate", "IsApproved", "IsSubmitted", "SubmittedDate", "SubmittedPerson" },
                values: new object[] { null, null, new DateTime(2025, 3, 26, 19, 42, 15, 396, DateTimeKind.Local).AddTicks(4537), null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                columns: new[] { "ApprovedDate", "ApprovedPerson", "CreatedDate", "IsApproved", "IsSubmitted", "SubmittedDate", "SubmittedPerson" },
                values: new object[] { null, null, new DateTime(2025, 3, 26, 19, 42, 15, 399, DateTimeKind.Local).AddTicks(3533), null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 26, 19, 42, 15, 398, DateTimeKind.Local).AddTicks(7628));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 26, 19, 42, 15, 399, DateTimeKind.Local).AddTicks(3621));
        }
    }
}
