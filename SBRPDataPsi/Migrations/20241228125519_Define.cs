using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class Define : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Supplier_SupplierId",
                schema: "psi",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Store_StoreId",
                schema: "psi",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_PermissionGroup_PermissionGroupId",
                schema: "psi",
                table: "PermissionGroup");

            migrationBuilder.DropIndex(
                name: "IX_BaseWebPageTemplate_PageId",
                schema: "psi",
                table: "BaseWebPageTemplate");

            migrationBuilder.CreateSequence<int>(
                name: "seqProduct",
                schema: "psi",
                startValue: 10001L);

            migrationBuilder.CreateSequence<byte>(
                name: "seqProductGeneralCategoryDefinition",
                schema: "psi",
                startValue: 11L);

            migrationBuilder.CreateSequence<short>(
                name: "seqProductGeneralCategoryItem",
                schema: "psi",
                startValue: 7001L);

            migrationBuilder.AlterColumn<string>(
                name: "SubFolder2",
                schema: "psi",
                table: "BaseWebPageTemplate",
                type: "VARCHAR(28)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(24)");

            migrationBuilder.CreateTable(
                name: "PermissionGroupAppUser",
                schema: "psi",
                columns: table => new
                {
                    PermissionGroupNo = table.Column<short>(type: "smallint", nullable: false),
                    UserNo = table.Column<short>(type: "smallint", nullable: false),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroupAppUser", x => new { x.PermissionGroupNo, x.UserNo });
                    table.ForeignKey(
                        name: "FK_PermissionGroupAppUser_AppUser_UserNo",
                        column: x => x.UserNo,
                        principalSchema: "psi",
                        principalTable: "AppUser",
                        principalColumn: "UserNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionGroupAppUser_PermissionGroup_PermissionGroupNo",
                        column: x => x.PermissionGroupNo,
                        principalSchema: "psi",
                        principalTable: "PermissionGroup",
                        principalColumn: "PermissionGroupNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "psi",
                columns: table => new
                {
                    ProductNo = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR psi.seqProduct"),
                    ProductId = table.Column<string>(type: "CHAR(32)", nullable: true),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ParentProductNo = table.Column<int>(type: "int", nullable: true),
                    IsParentalProduct = table.Column<bool>(type: "bit", nullable: false),
                    IsNotForOrderProcessing = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsInvisible = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductNo);
                });

            migrationBuilder.CreateTable(
                name: "ProductGeneralCategoryDefinition",
                schema: "psi",
                columns: table => new
                {
                    PGCategoryNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "NEXT VALUE FOR psi.seqProductGeneralCategoryDefinition"),
                    PGCategoryId = table.Column<string>(type: "CHAR(16)", nullable: false),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false),
                    PGCategoryName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ItemIdMinLength = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    ItemIdMaxLength = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    PGCOrderNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "0"),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsInvisible = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGeneralCategoryDefinition", x => x.PGCategoryNo);
                });

            migrationBuilder.CreateTable(
                name: "ProductGeneralCategory",
                schema: "psi",
                columns: table => new
                {
                    ProductNo = table.Column<int>(type: "int", nullable: false),
                    PGCategoryNo = table.Column<byte>(type: "tinyint", nullable: false),
                    PGCItemNo = table.Column<short>(type: "smallint", nullable: false),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGeneralCategory", x => new { x.ProductNo, x.PGCategoryNo });
                    table.ForeignKey(
                        name: "FK_ProductGeneralCategory_ProductGeneralCategoryDefinition_PGCategoryNo",
                        column: x => x.PGCategoryNo,
                        principalSchema: "psi",
                        principalTable: "ProductGeneralCategoryDefinition",
                        principalColumn: "PGCategoryNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductGeneralCategory_Product_ProductNo",
                        column: x => x.ProductNo,
                        principalSchema: "psi",
                        principalTable: "Product",
                        principalColumn: "ProductNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductGeneralCategoryItem",
                schema: "psi",
                columns: table => new
                {
                    PGCItemNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR psi.seqProductGeneralCategoryItem"),
                    PGCategoryNo = table.Column<byte>(type: "tinyint", nullable: false),
                    PGCItemId = table.Column<string>(type: "CHAR(16)", maxLength: 16, nullable: false),
                    PGCItemName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    PGCItemColorHex = table.Column<string>(type: "CHAR(6)", nullable: true),
                    PGCItemNumericValue = table.Column<int>(type: "int", nullable: true),
                    PGCItemImagePathFileName = table.Column<string>(type: "VARCHAR(32)", nullable: true),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGeneralCategoryItem", x => x.PGCItemNo);
                    table.ForeignKey(
                        name: "FK_ProductGeneralCategoryItem_ProductGeneralCategoryDefinition_PGCategoryNo",
                        column: x => x.PGCategoryNo,
                        principalSchema: "psi",
                        principalTable: "ProductGeneralCategoryDefinition",
                        principalColumn: "PGCategoryNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductIdStructureDefinition",
                schema: "psi",
                columns: table => new
                {
                    PGCOrderNo = table.Column<short>(type: "smallint", nullable: false),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false),
                    PGCategoryNo = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductIdStructureDefinition", x => new { x.PGCOrderNo, x.SIGNo });
                    table.ForeignKey(
                        name: "FK_ProductIdStructureDefinition_ProductGeneralCategoryDefinition_PGCategoryNo",
                        column: x => x.PGCategoryNo,
                        principalSchema: "psi",
                        principalTable: "ProductGeneralCategoryDefinition",
                        principalColumn: "PGCategoryNo",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroup_PermissionGroupId_SIGNo",
                schema: "psi",
                table: "PermissionGroup",
                columns: new[] { "PermissionGroupId", "SIGNo" },
                unique: true,
                filter: "[PermissionGroupId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MenuitemSIG_OrderNo",
                schema: "psi",
                table: "MenuitemSIG",
                column: "OrderNo");

            migrationBuilder.CreateIndex(
                name: "IX_Menuitem_ParentNodeId",
                schema: "psi",
                table: "Menuitem",
                column: "ParentNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroupAppUser_UserNo",
                schema: "psi",
                table: "PermissionGroupAppUser",
                column: "UserNo");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ParentProductNo",
                schema: "psi",
                table: "Product",
                column: "ParentProductNo");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductId_SIGNo",
                schema: "psi",
                table: "Product",
                columns: new[] { "ProductId", "SIGNo" },
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGeneralCategory_PGCategoryNo",
                schema: "psi",
                table: "ProductGeneralCategory",
                column: "PGCategoryNo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGeneralCategory_PGCItemNo",
                schema: "psi",
                table: "ProductGeneralCategory",
                column: "PGCItemNo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGeneralCategoryDefinition_PGCategoryId_SIGNo",
                schema: "psi",
                table: "ProductGeneralCategoryDefinition",
                columns: new[] { "PGCategoryId", "SIGNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductGeneralCategoryDefinition_PGCOrderNo",
                schema: "psi",
                table: "ProductGeneralCategoryDefinition",
                column: "PGCOrderNo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGeneralCategoryItem_PGCategoryNo",
                schema: "psi",
                table: "ProductGeneralCategoryItem",
                column: "PGCategoryNo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGeneralCategoryItem_PGCategoryNo_PGCItemId",
                schema: "psi",
                table: "ProductGeneralCategoryItem",
                columns: new[] { "PGCategoryNo", "PGCItemId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductIdStructureDefinition_PGCategoryNo",
                schema: "psi",
                table: "ProductIdStructureDefinition",
                column: "PGCategoryNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionGroupAppUser",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "ProductGeneralCategory",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "ProductGeneralCategoryItem",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "ProductIdStructureDefinition",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "ProductGeneralCategoryDefinition",
                schema: "psi");

            migrationBuilder.DropIndex(
                name: "IX_PermissionGroup_PermissionGroupId_SIGNo",
                schema: "psi",
                table: "PermissionGroup");

            migrationBuilder.DropIndex(
                name: "IX_MenuitemSIG_OrderNo",
                schema: "psi",
                table: "MenuitemSIG");

            migrationBuilder.DropIndex(
                name: "IX_Menuitem_ParentNodeId",
                schema: "psi",
                table: "Menuitem");

            migrationBuilder.DropSequence(
                name: "seqProduct",
                schema: "psi");

            migrationBuilder.DropSequence(
                name: "seqProductGeneralCategoryDefinition",
                schema: "psi");

            migrationBuilder.DropSequence(
                name: "seqProductGeneralCategoryItem",
                schema: "psi");

            migrationBuilder.AlterColumn<string>(
                name: "SubFolder2",
                schema: "psi",
                table: "BaseWebPageTemplate",
                type: "VARCHAR(24)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(28)");

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
                name: "IX_Supplier_SupplierId",
                schema: "psi",
                table: "Supplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_StoreId",
                schema: "psi",
                table: "Store",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroup_PermissionGroupId",
                schema: "psi",
                table: "PermissionGroup",
                column: "PermissionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWebPageTemplate_PageId",
                schema: "psi",
                table: "BaseWebPageTemplate",
                column: "PageId");
        }
    }
}
