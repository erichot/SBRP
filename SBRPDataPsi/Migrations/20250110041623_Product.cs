using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "seqMenuitem",
                schema: "psi");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                schema: "psi",
                table: "ProductGeneralCategoryItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<short>(
                name: "PGCItemOrderNo",
                schema: "psi",
                table: "ProductGeneralCategoryItem",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<short>(
                name: "PGCItemNo",
                schema: "psi",
                table: "ProductGeneralCategory",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "AspController",
                schema: "psi",
                table: "Menuitem",
                type: "VARCHAR(28)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(16)",
                oldNullable: true);

            //migrationBuilder.AlterColumn<short>(
            //    name: "NodeNo",
            //    schema: "psi",
            //    table: "Menuitem",
            //    type: "smallint",
            //    nullable: false,
            //    oldClrType: typeof(short),
            //    oldType: "smallint",
            //    oldDefaultValueSql: "NEXT VALUE FOR psi.seqMenuitem")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "ProductSupplier",
                schema: "psi",
                columns: table => new
                {
                    ProductNo = table.Column<int>(type: "int", nullable: false),
                    SupplierNo = table.Column<short>(type: "smallint", nullable: false),
                    ItemNo = table.Column<byte>(type: "tinyint", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplier", x => new { x.ProductNo, x.SupplierNo, x.ItemNo });
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Product_ProductNo",
                        column: x => x.ProductNo,
                        principalSchema: "psi",
                        principalTable: "Product",
                        principalColumn: "ProductNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Supplier_SupplierNo",
                        column: x => x.SupplierNo,
                        principalSchema: "psi",
                        principalTable: "Supplier",
                        principalColumn: "SupplierNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 12, 16, 19, 712, DateTimeKind.Local).AddTicks(4075));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 12, 16, 19, 712, DateTimeKind.Local).AddTicks(6264));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 12, 16, 19, 709, DateTimeKind.Local).AddTicks(9143));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 12, 16, 19, 712, DateTimeKind.Local).AddTicks(6757));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 12, 16, 19, 712, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 10, 12, 16, 19, 712, DateTimeKind.Local).AddTicks(6872));

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_SupplierNo",
                schema: "psi",
                table: "ProductSupplier",
                column: "SupplierNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSupplier",
                schema: "psi");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                schema: "psi",
                table: "ProductGeneralCategoryItem");

            migrationBuilder.DropColumn(
                name: "PGCItemOrderNo",
                schema: "psi",
                table: "ProductGeneralCategoryItem");

            migrationBuilder.CreateSequence<short>(
                name: "seqMenuitem",
                schema: "psi",
                startValue: 301L);

            migrationBuilder.AlterColumn<short>(
                name: "PGCItemNo",
                schema: "psi",
                table: "ProductGeneralCategory",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AspController",
                schema: "psi",
                table: "Menuitem",
                type: "VARCHAR(16)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(28)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "NodeNo",
                schema: "psi",
                table: "Menuitem",
                type: "smallint",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR psi.seqMenuitem",
                oldClrType: typeof(short),
                oldType: "smallint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Company",
                keyColumn: "CompanyNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 20, 55, 16, 394, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Department",
                keyColumn: "DepartmentNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 20, 55, 16, 394, DateTimeKind.Local).AddTicks(9241));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 20, 55, 16, 392, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "Person",
                keyColumn: "PersonNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 20, 55, 16, 394, DateTimeKind.Local).AddTicks(9704));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)-1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 20, 55, 16, 394, DateTimeKind.Local).AddTicks(4967));

            migrationBuilder.UpdateData(
                schema: "common",
                table: "User",
                keyColumn: "UserNo",
                keyValue: (short)1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 20, 55, 16, 394, DateTimeKind.Local).AddTicks(9774));
        }
    }
}
