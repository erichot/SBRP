using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataPsi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "psi");

            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.CreateSequence<short>(
                name: "seqCompany",
                schema: "common",
                startValue: 5001L);

            migrationBuilder.CreateSequence<short>(
                name: "seqDepartment",
                schema: "common",
                startValue: 2001L);

            migrationBuilder.CreateSequence<short>(
                name: "seqDivisionNo",
                schema: "common",
                startValue: 1601L);

            migrationBuilder.CreateSequence<int>(
                name: "seqEmployee",
                schema: "common",
                startValue: 10001L);

            migrationBuilder.CreateSequence<short>(
                name: "seqMenuitem",
                schema: "psi",
                startValue: 301L);

            migrationBuilder.CreateSequence<short>(
                name: "seqPermissionGroup",
                schema: "psi",
                startValue: 3001L);

            migrationBuilder.CreateSequence<short>(
                name: "seqPosition",
                schema: "common",
                startValue: 1001L);

            migrationBuilder.CreateSequence<short>(
                name: "seqSupplier",
                schema: "psi",
                startValue: 5001L);

            migrationBuilder.CreateSequence<byte>(
                name: "seqSystemIsolationGroup",
                schema: "common",
                startValue: 11L);

            migrationBuilder.CreateSequence<short>(
                name: "seqUser",
                schema: "common",
                startValue: 3001L);

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "common",
                columns: table => new
                {
                    CompanyNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR common.seqCompany"),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    CompanyId = table.Column<string>(type: "CHAR(16)", maxLength: 16, nullable: false),
                    TaxId = table.Column<string>(type: "CHAR(10)", maxLength: 10, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CompanyNameAbbr = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CompanyDirector = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CompanyPhone = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: true),
                    CompanyWeb = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: true),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: true),
                    SubmittedPerson = table.Column<short>(type: "smallint", nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedPerson = table.Column<short>(type: "smallint", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyNo);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                schema: "common",
                columns: table => new
                {
                    DivisionNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR common.seqDivisionNo"),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    DivisionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DivisionName = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    DivisionNameAbbr = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsInvisible = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: true),
                    SubmittedPerson = table.Column<short>(type: "smallint", nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedPerson = table.Column<short>(type: "smallint", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionNo);
                });

            migrationBuilder.CreateTable(
                name: "Menuitem",
                schema: "psi",
                columns: table => new
                {
                    NodeNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR psi.seqMenuitem"),
                    NodeId = table.Column<string>(type: "CHAR(8)", nullable: false),
                    HasChildNode = table.Column<bool>(type: "bit", nullable: false),
                    ParentNodeId = table.Column<string>(type: "CHAR(8)", nullable: true),
                    NodeName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    AspPage = table.Column<string>(type: "VARCHAR(48)", nullable: false),
                    AspController = table.Column<string>(type: "VARCHAR(16)", nullable: true),
                    AspAction = table.Column<string>(type: "VARCHAR(16)", nullable: true),
                    AspRouteNo = table.Column<short>(type: "smallint", nullable: false),
                    DataFeather = table.Column<string>(type: "VARCHAR(16)", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ThresholdPermissionValue = table.Column<short>(type: "smallint", nullable: false),
                    RoleTypeFlag = table.Column<byte>(type: "tinyint", nullable: false),
                    OrderNo = table.Column<short>(type: "smallint", nullable: false),
                    Version = table.Column<string>(type: "VARCHAR(8)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    IsIsolated = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsInvisible = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menuitem", x => x.NodeNo);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "common",
                columns: table => new
                {
                    PersonNo = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR common.seqEmployee"),
                    PersonId = table.Column<string>(type: "CHAR(16)", nullable: true),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    PersonName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: true),
                    SubmittedPerson = table.Column<short>(type: "smallint", nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedPerson = table.Column<short>(type: "smallint", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonNo);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                schema: "common",
                columns: table => new
                {
                    PositionNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR common.seqPosition"),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    PositionId = table.Column<string>(type: "CHAR(12)", nullable: true),
                    PositionName = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    PositionNameAbbr = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: true),
                    SubmittedPerson = table.Column<short>(type: "smallint", nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedPerson = table.Column<short>(type: "smallint", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionNo);
                });

            migrationBuilder.CreateTable(
                name: "SystemIsolationGroup",
                schema: "common",
                columns: table => new
                {
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "NEXT VALUE FOR common.seqSystemIsolationGroup"),
                    SIGId = table.Column<string>(type: "CHAR(12)", nullable: false),
                    SIGName = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    CompanyNo = table.Column<short>(type: "smallint", nullable: false),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: true),
                    SubmittedPerson = table.Column<short>(type: "smallint", nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedPerson = table.Column<short>(type: "smallint", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemIsolationGroup", x => x.SIGNo);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginHistory",
                schema: "common",
                columns: table => new
                {
                    UserLoginHistoryNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginId = table.Column<string>(type: "VARCHAR(32)", nullable: true),
                    AppId = table.Column<byte>(type: "tinyint", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    IsAccountDisabled = table.Column<bool>(type: "bit", nullable: false),
                    HasBeenLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsLoginSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    LoginActionNo = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginHistory", x => x.UserLoginHistoryNo);
                });

            migrationBuilder.CreateTable(
                name: "UserPasswordHistory",
                schema: "common",
                columns: table => new
                {
                    HistoryNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNo = table.Column<short>(type: "smallint", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(128)", nullable: true),
                    LoginActionNo = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPasswordHistory", x => x.HistoryNo);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "psi",
                columns: table => new
                {
                    SupplierNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR psi.seqSupplier"),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    CompanyNo = table.Column<short>(type: "smallint", nullable: false),
                    SupplierId = table.Column<string>(type: "CHAR(16)", maxLength: 16, nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    SupplierNameAbbr = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    BillingPeriodType = table.Column<byte>(type: "tinyint", nullable: true),
                    BillingPeriodDay = table.Column<byte>(type: "tinyint", nullable: true),
                    PaymentPeriodType = table.Column<byte>(type: "tinyint", nullable: true),
                    PaymentPeriodDay = table.Column<byte>(type: "tinyint", nullable: true),
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
                    table.PrimaryKey("PK_Supplier", x => x.SupplierNo);
                    table.ForeignKey(
                        name: "FK_Supplier_Company_CompanyNo",
                        column: x => x.CompanyNo,
                        principalSchema: "common",
                        principalTable: "Company",
                        principalColumn: "CompanyNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "common",
                columns: table => new
                {
                    DepartmentNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR common.seqDepartment"),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    DepartmentNameAbbr = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    DivisionNo = table.Column<short>(type: "smallint", nullable: true),
                    ParentDepartmentNo = table.Column<short>(type: "smallint", nullable: true),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: true),
                    SubmittedPerson = table.Column<short>(type: "smallint", nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedPerson = table.Column<short>(type: "smallint", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentNo);
                    table.ForeignKey(
                        name: "FK_Department_Department_ParentDepartmentNo",
                        column: x => x.ParentDepartmentNo,
                        principalSchema: "common",
                        principalTable: "Department",
                        principalColumn: "DepartmentNo");
                    table.ForeignKey(
                        name: "FK_Department_Division_DivisionNo",
                        column: x => x.DivisionNo,
                        principalSchema: "common",
                        principalTable: "Division",
                        principalColumn: "DivisionNo");
                });

            migrationBuilder.CreateTable(
                name: "MenuitemSIG",
                schema: "psi",
                columns: table => new
                {
                    NodeNo = table.Column<short>(type: "smallint", nullable: false),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false),
                    NodeName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OrderNo = table.Column<short>(type: "smallint", nullable: true),
                    IsInvisible = table.Column<bool>(type: "bit", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: true),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuitemSIG", x => new { x.NodeNo, x.SIGNo });
                    table.ForeignKey(
                        name: "FK_MenuitemSIG_Menuitem_NodeNo",
                        column: x => x.NodeNo,
                        principalSchema: "psi",
                        principalTable: "Menuitem",
                        principalColumn: "NodeNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyContactPerson",
                schema: "common",
                columns: table => new
                {
                    CompanyNo = table.Column<short>(type: "smallint", nullable: false),
                    ContactItemNo = table.Column<short>(type: "smallint", nullable: false),
                    PersonNo = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ContactPhone = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: true),
                    MobilePhone = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: true),
                    EmailAddress = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContactPerson", x => new { x.CompanyNo, x.ContactItemNo });
                    table.ForeignKey(
                        name: "FK_CompanyContactPerson_Company_CompanyNo",
                        column: x => x.CompanyNo,
                        principalSchema: "common",
                        principalTable: "Company",
                        principalColumn: "CompanyNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyContactPerson_Person_PersonNo",
                        column: x => x.PersonNo,
                        principalSchema: "common",
                        principalTable: "Person",
                        principalColumn: "PersonNo");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "common",
                columns: table => new
                {
                    EmployeeNo = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    EmployeeId = table.Column<string>(type: "CHAR(16)", nullable: true),
                    PersonNo = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR common.seqEmployee"),
                    PositionNo = table.Column<short>(type: "smallint", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsInvisible = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Remark = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: true),
                    SubmittedPerson = table.Column<short>(type: "smallint", nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedPerson = table.Column<short>(type: "smallint", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeNo);
                    table.ForeignKey(
                        name: "FK_Employee_Person_PersonNo",
                        column: x => x.PersonNo,
                        principalSchema: "common",
                        principalTable: "Person",
                        principalColumn: "PersonNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "common",
                columns: table => new
                {
                    UserNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR common.seqUser"),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    UserId = table.Column<string>(type: "CHAR(16)", nullable: true),
                    EmployeeNo = table.Column<short>(type: "smallint", nullable: true),
                    PersonNo = table.Column<int>(type: "int", nullable: false),
                    UserGroupNo = table.Column<short>(type: "smallint", nullable: false),
                    UserRoleNo = table.Column<short>(type: "smallint", nullable: false),
                    LoginId = table.Column<string>(type: "CHAR(32)", nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR(128)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReadonly = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsLoggedOn = table.Column<bool>(type: "bit", nullable: true),
                    HasBeenLocked = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    ExpirationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: true),
                    SubmittedPerson = table.Column<short>(type: "smallint", nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedPerson = table.Column<short>(type: "smallint", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoggedOnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoggedOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPasswordFailedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordFailureAttemptCount = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserNo);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonNo",
                        column: x => x.PersonNo,
                        principalSchema: "common",
                        principalTable: "Person",
                        principalColumn: "PersonNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroup",
                schema: "psi",
                columns: table => new
                {
                    PermissionGroupNo = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "NEXT VALUE FOR psi.seqPermissionGroup"),
                    SIGNo = table.Column<byte>(type: "tinyint", nullable: false),
                    PermissionGroupId = table.Column<string>(type: "CHAR(24)", nullable: true),
                    PermissionGroupName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DepartmentNo = table.Column<short>(type: "smallint", nullable: true),
                    PositionNo = table.Column<short>(type: "smallint", nullable: true),
                    IsSystemPredefined = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsInvisible = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
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
                    table.PrimaryKey("PK_PermissionGroup", x => x.PermissionGroupNo);
                    table.ForeignKey(
                        name: "FK_PermissionGroup_Department_DepartmentNo",
                        column: x => x.DepartmentNo,
                        principalSchema: "common",
                        principalTable: "Department",
                        principalColumn: "DepartmentNo");
                    table.ForeignKey(
                        name: "FK_PermissionGroup_Position_PositionNo",
                        column: x => x.PositionNo,
                        principalSchema: "common",
                        principalTable: "Position",
                        principalColumn: "PositionNo");
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                schema: "psi",
                columns: table => new
                {
                    UserNo = table.Column<short>(type: "smallint", nullable: false),
                    AppUserGroupNo = table.Column<short>(type: "smallint", nullable: false),
                    AppUserRoleNo = table.Column<short>(type: "smallint", nullable: false),
                    IsAppReadonly = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsAppDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    AppExpirationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedPerson = table.Column<short>(type: "smallint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.UserNo);
                    table.ForeignKey(
                        name: "FK_AppUser_User_UserNo",
                        column: x => x.UserNo,
                        principalSchema: "common",
                        principalTable: "User",
                        principalColumn: "UserNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginToken",
                schema: "common",
                columns: table => new
                {
                    IssuedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UserNo = table.Column<short>(type: "smallint", nullable: false),
                    SerialNo = table.Column<byte>(type: "tinyint", nullable: false),
                    LoginActionNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebToken = table.Column<string>(type: "CHAR(32)", nullable: false),
                    AppId = table.Column<byte>(type: "tinyint", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InValid = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    InvalidDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginToken", x => new { x.IssuedDate, x.UserNo, x.SerialNo });
                    table.ForeignKey(
                        name: "FK_UserLoginToken_User_UserNo",
                        column: x => x.UserNo,
                        principalSchema: "common",
                        principalTable: "User",
                        principalColumn: "UserNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuitemPermissionGroup",
                schema: "psi",
                columns: table => new
                {
                    NodeNo = table.Column<short>(type: "smallint", nullable: false),
                    PermissionGroupNo = table.Column<short>(type: "smallint", nullable: false),
                    IsReadonly = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuitemPermissionGroup", x => new { x.NodeNo, x.PermissionGroupNo });
                    table.ForeignKey(
                        name: "FK_MenuitemPermissionGroup_Menuitem_NodeNo",
                        column: x => x.NodeNo,
                        principalSchema: "psi",
                        principalTable: "Menuitem",
                        principalColumn: "NodeNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuitemPermissionGroup_PermissionGroup_PermissionGroupNo",
                        column: x => x.PermissionGroupNo,
                        principalSchema: "psi",
                        principalTable: "PermissionGroup",
                        principalColumn: "PermissionGroupNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuitemAppUser",
                schema: "psi",
                columns: table => new
                {
                    NodeNo = table.Column<short>(type: "smallint", nullable: false),
                    AppUserNo = table.Column<short>(type: "smallint", nullable: false),
                    IsReadonly = table.Column<bool>(type: "bit", nullable: false),
                    CreatedPerson = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedPerson = table.Column<short>(type: "smallint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuitemAppUser", x => new { x.NodeNo, x.AppUserNo });
                    table.ForeignKey(
                        name: "FK_MenuitemAppUser_AppUser_AppUserNo",
                        column: x => x.AppUserNo,
                        principalSchema: "psi",
                        principalTable: "AppUser",
                        principalColumn: "UserNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuitemAppUser_Menuitem_NodeNo",
                        column: x => x.NodeNo,
                        principalSchema: "psi",
                        principalTable: "Menuitem",
                        principalColumn: "NodeNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "common",
                table: "Company",
                columns: new[] { "CompanyNo", "ApprovedDate", "ApprovedPerson", "CompanyAddress", "CompanyDirector", "CompanyId", "CompanyName", "CompanyNameAbbr", "CompanyPhone", "CompanyWeb", "CreatedDate", "CreatedPerson", "DeletedDate", "DeletedPerson", "IsApproved", "IsDisabled", "IsSubmitted", "IsSystemPredefined", "PostalAddress", "Remark", "SubmittedDate", "SubmittedPerson", "TaxId", "UpdatedDate", "UpdatedPerson" },
                values: new object[] { (short)-1, null, null, "", "", "_PREDEF_", "(PreDefine)", "PreDef", "", "", new DateTime(2024, 12, 17, 20, 31, 15, 778, DateTimeKind.Local).AddTicks(4135), (short)90, null, null, null, true, null, true, "", "", null, null, "_PREDEF_", null, null });

            migrationBuilder.InsertData(
                schema: "common",
                table: "Department",
                columns: new[] { "DepartmentNo", "ApprovedDate", "ApprovedPerson", "CreatedDate", "CreatedPerson", "DeletedDate", "DeletedPerson", "DepartmentId", "DepartmentName", "DepartmentNameAbbr", "DivisionNo", "IsApproved", "IsDisabled", "IsSubmitted", "IsSystemPredefined", "ParentDepartmentNo", "Remark", "SubmittedDate", "SubmittedPerson", "UpdatedDate", "UpdatedPerson" },
                values: new object[] { (short)-1, null, null, new DateTime(2024, 12, 17, 20, 31, 15, 778, DateTimeKind.Local).AddTicks(6373), (short)90, null, null, "_PREDEF_", "(PreDefine)", "PreDef", null, null, true, null, true, null, "", null, null, null, null });

            migrationBuilder.InsertData(
                schema: "common",
                table: "Person",
                columns: new[] { "PersonNo", "ApprovedDate", "ApprovedPerson", "CreatedDate", "CreatedPerson", "DeletedDate", "DeletedPerson", "IsApproved", "IsDisabled", "IsSubmitted", "IsSystemPredefined", "PersonId", "PersonName", "Remark", "SubmittedDate", "SubmittedPerson", "UpdatedDate", "UpdatedPerson" },
                values: new object[] { -1, null, null, new DateTime(2024, 12, 17, 20, 31, 15, 775, DateTimeKind.Local).AddTicks(7960), (short)90, null, null, null, true, null, true, "_PREDEF_", "(PreDefine)", "", null, null, null, null });

            migrationBuilder.InsertData(
                schema: "common",
                table: "Person",
                columns: new[] { "PersonNo", "ApprovedDate", "ApprovedPerson", "CreatedDate", "CreatedPerson", "DeletedDate", "DeletedPerson", "IsApproved", "IsSubmitted", "IsSystemPredefined", "PersonId", "PersonName", "Remark", "SubmittedDate", "SubmittedPerson", "UpdatedDate", "UpdatedPerson" },
                values: new object[] { 1, null, null, new DateTime(2024, 12, 17, 20, 31, 15, 778, DateTimeKind.Local).AddTicks(7026), (short)90, null, null, null, null, true, "ADMIN", "ADMINISTRATOR", "", null, null, null, null });

            migrationBuilder.InsertData(
                schema: "common",
                table: "User",
                columns: new[] { "UserNo", "ApprovedDate", "ApprovedPerson", "CreatedDate", "CreatedPerson", "DeletedDate", "DeletedPerson", "Email", "EmployeeNo", "ExpirationDate", "IsApproved", "IsDisabled", "IsLoggedOn", "IsSubmitted", "IsSystemPredefined", "LastLoggedOnDate", "LastLoggedOutDate", "LastPasswordFailedDate", "LockedDate", "LoginId", "PasswordFailureAttemptCount", "PasswordHash", "PersonNo", "SubmittedDate", "SubmittedPerson", "UpdatedDate", "UpdatedPerson", "UserGroupNo", "UserId", "UserRoleNo" },
                values: new object[] { (short)-1, null, null, new DateTime(2024, 12, 17, 20, 31, 15, 778, DateTimeKind.Local).AddTicks(1858), (short)90, null, null, "", null, null, null, true, null, null, true, null, null, null, null, "", null, "_PREDEF_", -1, null, null, null, null, (short)0, "_PREDEF_", (short)0 });

            migrationBuilder.InsertData(
                schema: "common",
                table: "User",
                columns: new[] { "UserNo", "ApprovedDate", "ApprovedPerson", "CreatedDate", "CreatedPerson", "DeletedDate", "DeletedPerson", "Email", "EmployeeNo", "ExpirationDate", "IsApproved", "IsLoggedOn", "IsSubmitted", "IsSystemPredefined", "LastLoggedOnDate", "LastLoggedOutDate", "LastPasswordFailedDate", "LockedDate", "LoginId", "PasswordFailureAttemptCount", "PasswordHash", "PersonNo", "SubmittedDate", "SubmittedPerson", "UpdatedDate", "UpdatedPerson", "UserGroupNo", "UserId", "UserRoleNo" },
                values: new object[] { (short)1, null, null, new DateTime(2024, 12, 17, 20, 31, 15, 778, DateTimeKind.Local).AddTicks(7099), (short)90, null, null, "", null, null, null, null, null, true, null, null, null, null, "", null, "MjZALnvidPPUogKCJ8w9wg==", 1, null, null, null, null, (short)0, "ADMIN", (short)0 });

            migrationBuilder.InsertData(
                schema: "psi",
                table: "AppUser",
                columns: new[] { "UserNo", "AppExpirationDate", "AppUserGroupNo", "AppUserRoleNo", "CreatedPerson", "DeletedDate", "DeletedPerson", "UpdatedDate", "UpdatedPerson" },
                values: new object[] { (short)1, null, (short)0, (short)0, (short)0, null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyId",
                schema: "common",
                table: "Company",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContactPerson_PersonNo",
                schema: "common",
                table: "CompanyContactPerson",
                column: "PersonNo");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepartmentId",
                schema: "common",
                table: "Department",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DivisionNo",
                schema: "common",
                table: "Department",
                column: "DivisionNo");

            migrationBuilder.CreateIndex(
                name: "IX_Department_ParentDepartmentNo",
                schema: "common",
                table: "Department",
                column: "ParentDepartmentNo");

            migrationBuilder.CreateIndex(
                name: "IX_Division_DivisionId",
                schema: "common",
                table: "Division",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeId",
                schema: "common",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PersonNo",
                schema: "common",
                table: "Employee",
                column: "PersonNo");

            migrationBuilder.CreateIndex(
                name: "IX_Menuitem_NodeId",
                schema: "psi",
                table: "Menuitem",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuitemAppUser_AppUserNo",
                schema: "psi",
                table: "MenuitemAppUser",
                column: "AppUserNo");

            migrationBuilder.CreateIndex(
                name: "IX_MenuitemPermissionGroup_PermissionGroupNo",
                schema: "psi",
                table: "MenuitemPermissionGroup",
                column: "PermissionGroupNo");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroup_DepartmentNo",
                schema: "psi",
                table: "PermissionGroup",
                column: "DepartmentNo");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroup_PermissionGroupId",
                schema: "psi",
                table: "PermissionGroup",
                column: "PermissionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroup_PositionNo",
                schema: "psi",
                table: "PermissionGroup",
                column: "PositionNo");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonId",
                schema: "common",
                table: "Person",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_PositionId",
                schema: "common",
                table: "Position",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CompanyNo",
                schema: "psi",
                table: "Supplier",
                column: "CompanyNo");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SupplierId",
                schema: "psi",
                table: "Supplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemIsolationGroup_SIGId",
                schema: "common",
                table: "SystemIsolationGroup",
                column: "SIGId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_LoginId",
                schema: "common",
                table: "User",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonNo",
                schema: "common",
                table: "User",
                column: "PersonNo");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginToken_UserNo",
                schema: "common",
                table: "UserLoginToken",
                column: "UserNo");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginToken_WebToken",
                schema: "common",
                table: "UserLoginToken",
                column: "WebToken");

            migrationBuilder.CreateIndex(
                name: "IX_UserPasswordHistory_UserNo",
                schema: "common",
                table: "UserPasswordHistory",
                column: "UserNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyContactPerson",
                schema: "common");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "common");

            migrationBuilder.DropTable(
                name: "MenuitemAppUser",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "MenuitemPermissionGroup",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "MenuitemSIG",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "SystemIsolationGroup",
                schema: "common");

            migrationBuilder.DropTable(
                name: "UserLoginHistory",
                schema: "common");

            migrationBuilder.DropTable(
                name: "UserLoginToken",
                schema: "common");

            migrationBuilder.DropTable(
                name: "UserPasswordHistory",
                schema: "common");

            migrationBuilder.DropTable(
                name: "AppUser",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "PermissionGroup",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "Menuitem",
                schema: "psi");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "common");

            migrationBuilder.DropTable(
                name: "User",
                schema: "common");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "common");

            migrationBuilder.DropTable(
                name: "Position",
                schema: "common");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "common");

            migrationBuilder.DropTable(
                name: "Division",
                schema: "common");

            migrationBuilder.DropSequence(
                name: "seqCompany",
                schema: "common");

            migrationBuilder.DropSequence(
                name: "seqDepartment",
                schema: "common");

            migrationBuilder.DropSequence(
                name: "seqDivisionNo",
                schema: "common");

            migrationBuilder.DropSequence(
                name: "seqEmployee",
                schema: "common");

            migrationBuilder.DropSequence(
                name: "seqMenuitem",
                schema: "psi");

            migrationBuilder.DropSequence(
                name: "seqPermissionGroup",
                schema: "psi");

            migrationBuilder.DropSequence(
                name: "seqPosition",
                schema: "common");

            migrationBuilder.DropSequence(
                name: "seqSupplier",
                schema: "psi");

            migrationBuilder.DropSequence(
                name: "seqSystemIsolationGroup",
                schema: "common");

            migrationBuilder.DropSequence(
                name: "seqUser",
                schema: "common");
        }
    }
}
