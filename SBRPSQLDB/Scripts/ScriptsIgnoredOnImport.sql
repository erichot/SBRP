
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    --The following statement was imported into the database project as a schema object and named dbo.__EFMigrationsHistory.
--CREATE TABLE [__EFMigrationsHistory] (
--        [MigrationId] nvarchar(150) NOT NULL,
--        [ProductVersion] nvarchar(32) NOT NULL,
--        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
--    );

END;
GO

BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'psi') IS NULL EXEC(N'CREATE SCHEMA [psi];');
GO

IF SCHEMA_ID(N'common') IS NULL EXEC(N'CREATE SCHEMA [common];');
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CompanyNo', N'ApprovedDate', N'ApprovedPerson', N'CompanyAddress', N'CompanyDirector', N'CompanyId', N'CompanyName', N'CompanyNameAbbr', N'CompanyPhone', N'CompanyWeb', N'CreatedDate', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'IsApproved', N'IsDisabled', N'IsSubmitted', N'IsSystemPredefined', N'PostalAddress', N'Remark', N'SubmittedDate', N'SubmittedPerson', N'TaxId', N'UpdatedDate', N'UpdatedPerson') AND [object_id] = OBJECT_ID(N'[common].[Company]'))
    SET IDENTITY_INSERT [common].[Company] ON;
GO

INSERT INTO [common].[Company] ([CompanyNo], [ApprovedDate], [ApprovedPerson], [CompanyAddress], [CompanyDirector], [CompanyId], [CompanyName], [CompanyNameAbbr], [CompanyPhone], [CompanyWeb], [CreatedDate], [CreatedPerson], [DeletedDate], [DeletedPerson], [IsApproved], [IsDisabled], [IsSubmitted], [IsSystemPredefined], [PostalAddress], [Remark], [SubmittedDate], [SubmittedPerson], [TaxId], [UpdatedDate], [UpdatedPerson])
VALUES (CAST(-1 AS smallint), NULL, NULL, N'', N'', '_PREDEF_', N'(PreDefine)', N'PreDef', '', '', '2024-12-17T20:31:15.7784135+08:00', CAST(90 AS smallint), NULL, NULL, NULL, CAST(1 AS bit), NULL, CAST(1 AS bit), N'', N'', NULL, NULL, '_PREDEF_', NULL, NULL);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CompanyNo', N'ApprovedDate', N'ApprovedPerson', N'CompanyAddress', N'CompanyDirector', N'CompanyId', N'CompanyName', N'CompanyNameAbbr', N'CompanyPhone', N'CompanyWeb', N'CreatedDate', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'IsApproved', N'IsDisabled', N'IsSubmitted', N'IsSystemPredefined', N'PostalAddress', N'Remark', N'SubmittedDate', N'SubmittedPerson', N'TaxId', N'UpdatedDate', N'UpdatedPerson') AND [object_id] = OBJECT_ID(N'[common].[Company]'))
    SET IDENTITY_INSERT [common].[Company] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DepartmentNo', N'ApprovedDate', N'ApprovedPerson', N'CreatedDate', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'DepartmentId', N'DepartmentName', N'DepartmentNameAbbr', N'DivisionNo', N'IsApproved', N'IsDisabled', N'IsSubmitted', N'IsSystemPredefined', N'ParentDepartmentNo', N'Remark', N'SubmittedDate', N'SubmittedPerson', N'UpdatedDate', N'UpdatedPerson') AND [object_id] = OBJECT_ID(N'[common].[Department]'))
    SET IDENTITY_INSERT [common].[Department] ON;
GO

INSERT INTO [common].[Department] ([DepartmentNo], [ApprovedDate], [ApprovedPerson], [CreatedDate], [CreatedPerson], [DeletedDate], [DeletedPerson], [DepartmentId], [DepartmentName], [DepartmentNameAbbr], [DivisionNo], [IsApproved], [IsDisabled], [IsSubmitted], [IsSystemPredefined], [ParentDepartmentNo], [Remark], [SubmittedDate], [SubmittedPerson], [UpdatedDate], [UpdatedPerson])
VALUES (CAST(-1 AS smallint), NULL, NULL, '2024-12-17T20:31:15.7786373+08:00', CAST(90 AS smallint), NULL, NULL, N'_PREDEF_', N'(PreDefine)', N'PreDef', NULL, NULL, CAST(1 AS bit), NULL, CAST(1 AS bit), NULL, N'', NULL, NULL, NULL, NULL);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DepartmentNo', N'ApprovedDate', N'ApprovedPerson', N'CreatedDate', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'DepartmentId', N'DepartmentName', N'DepartmentNameAbbr', N'DivisionNo', N'IsApproved', N'IsDisabled', N'IsSubmitted', N'IsSystemPredefined', N'ParentDepartmentNo', N'Remark', N'SubmittedDate', N'SubmittedPerson', N'UpdatedDate', N'UpdatedPerson') AND [object_id] = OBJECT_ID(N'[common].[Department]'))
    SET IDENTITY_INSERT [common].[Department] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PersonNo', N'ApprovedDate', N'ApprovedPerson', N'CreatedDate', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'IsApproved', N'IsDisabled', N'IsSubmitted', N'IsSystemPredefined', N'PersonId', N'PersonName', N'Remark', N'SubmittedDate', N'SubmittedPerson', N'UpdatedDate', N'UpdatedPerson') AND [object_id] = OBJECT_ID(N'[common].[Person]'))
    SET IDENTITY_INSERT [common].[Person] ON;
GO

INSERT INTO [common].[Person] ([PersonNo], [ApprovedDate], [ApprovedPerson], [CreatedDate], [CreatedPerson], [DeletedDate], [DeletedPerson], [IsApproved], [IsDisabled], [IsSubmitted], [IsSystemPredefined], [PersonId], [PersonName], [Remark], [SubmittedDate], [SubmittedPerson], [UpdatedDate], [UpdatedPerson])
VALUES (-1, NULL, NULL, '2024-12-17T20:31:15.7757960+08:00', CAST(90 AS smallint), NULL, NULL, NULL, CAST(1 AS bit), NULL, CAST(1 AS bit), '_PREDEF_', N'(PreDefine)', N'', NULL, NULL, NULL, NULL);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PersonNo', N'ApprovedDate', N'ApprovedPerson', N'CreatedDate', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'IsApproved', N'IsDisabled', N'IsSubmitted', N'IsSystemPredefined', N'PersonId', N'PersonName', N'Remark', N'SubmittedDate', N'SubmittedPerson', N'UpdatedDate', N'UpdatedPerson') AND [object_id] = OBJECT_ID(N'[common].[Person]'))
    SET IDENTITY_INSERT [common].[Person] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PersonNo', N'ApprovedDate', N'ApprovedPerson', N'CreatedDate', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'IsApproved', N'IsSubmitted', N'IsSystemPredefined', N'PersonId', N'PersonName', N'Remark', N'SubmittedDate', N'SubmittedPerson', N'UpdatedDate', N'UpdatedPerson') AND [object_id] = OBJECT_ID(N'[common].[Person]'))
    SET IDENTITY_INSERT [common].[Person] ON;
GO

INSERT INTO [common].[Person] ([PersonNo], [ApprovedDate], [ApprovedPerson], [CreatedDate], [CreatedPerson], [DeletedDate], [DeletedPerson], [IsApproved], [IsSubmitted], [IsSystemPredefined], [PersonId], [PersonName], [Remark], [SubmittedDate], [SubmittedPerson], [UpdatedDate], [UpdatedPerson])
VALUES (1, NULL, NULL, '2024-12-17T20:31:15.7787026+08:00', CAST(90 AS smallint), NULL, NULL, NULL, NULL, CAST(1 AS bit), 'ADMIN', N'ADMINISTRATOR', N'', NULL, NULL, NULL, NULL);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PersonNo', N'ApprovedDate', N'ApprovedPerson', N'CreatedDate', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'IsApproved', N'IsSubmitted', N'IsSystemPredefined', N'PersonId', N'PersonName', N'Remark', N'SubmittedDate', N'SubmittedPerson', N'UpdatedDate', N'UpdatedPerson') AND [object_id] = OBJECT_ID(N'[common].[Person]'))
    SET IDENTITY_INSERT [common].[Person] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserNo', N'ApprovedDate', N'ApprovedPerson', N'CreatedDate', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'Email', N'EmployeeNo', N'ExpirationDate', N'IsApproved', N'IsDisabled', N'IsLoggedOn', N'IsSubmitted', N'IsSystemPredefined', N'LastLoggedOnDate', N'LastLoggedOutDate', N'LastPasswordFailedDate', N'LockedDate', N'LoginId', N'PasswordFailureAttemptCount', N'PasswordHash', N'PersonNo', N'SubmittedDate', N'SubmittedPerson', N'UpdatedDate', N'UpdatedPerson', N'UserGroupNo', N'UserId', N'UserRoleNo') AND [object_id] = OBJECT_ID(N'[common].[User]'))
    SET IDENTITY_INSERT [common].[User] ON;
GO

INSERT INTO [common].[User] ([UserNo], [ApprovedDate], [ApprovedPerson], [CreatedDate], [CreatedPerson], [DeletedDate], [DeletedPerson], [Email], [EmployeeNo], [ExpirationDate], [IsApproved], [IsDisabled], [IsLoggedOn], [IsSubmitted], [IsSystemPredefined], [LastLoggedOnDate], [LastLoggedOutDate], [LastPasswordFailedDate], [LockedDate], [LoginId], [PasswordFailureAttemptCount], [PasswordHash], [PersonNo], [SubmittedDate], [SubmittedPerson], [UpdatedDate], [UpdatedPerson], [UserGroupNo], [UserId], [UserRoleNo])
VALUES (CAST(-1 AS smallint), NULL, NULL, '2024-12-17T20:31:15.7781858+08:00', CAST(90 AS smallint), NULL, NULL, N'', NULL, NULL, NULL, CAST(1 AS bit), NULL, NULL, CAST(1 AS bit), NULL, NULL, NULL, NULL, '', NULL, '_PREDEF_', -1, NULL, NULL, NULL, NULL, CAST(0 AS smallint), '_PREDEF_', CAST(0 AS smallint));
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserNo', N'ApprovedDate', N'ApprovedPerson', N'CreatedDate', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'Email', N'EmployeeNo', N'ExpirationDate', N'IsApproved', N'IsDisabled', N'IsLoggedOn', N'IsSubmitted', N'IsSystemPredefined', N'LastLoggedOnDate', N'LastLoggedOutDate', N'LastPasswordFailedDate', N'LockedDate', N'LoginId', N'PasswordFailureAttemptCount', N'PasswordHash', N'PersonNo', N'SubmittedDate', N'SubmittedPerson', N'UpdatedDate', N'UpdatedPerson', N'UserGroupNo', N'UserId', N'UserRoleNo') AND [object_id] = OBJECT_ID(N'[common].[User]'))
    SET IDENTITY_INSERT [common].[User] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserNo', N'ApprovedDate', N'ApprovedPerson', N'CreatedDate', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'Email', N'EmployeeNo', N'ExpirationDate', N'IsApproved', N'IsLoggedOn', N'IsSubmitted', N'IsSystemPredefined', N'LastLoggedOnDate', N'LastLoggedOutDate', N'LastPasswordFailedDate', N'LockedDate', N'LoginId', N'PasswordFailureAttemptCount', N'PasswordHash', N'PersonNo', N'SubmittedDate', N'SubmittedPerson', N'UpdatedDate', N'UpdatedPerson', N'UserGroupNo', N'UserId', N'UserRoleNo') AND [object_id] = OBJECT_ID(N'[common].[User]'))
    SET IDENTITY_INSERT [common].[User] ON;
GO

INSERT INTO [common].[User] ([UserNo], [ApprovedDate], [ApprovedPerson], [CreatedDate], [CreatedPerson], [DeletedDate], [DeletedPerson], [Email], [EmployeeNo], [ExpirationDate], [IsApproved], [IsLoggedOn], [IsSubmitted], [IsSystemPredefined], [LastLoggedOnDate], [LastLoggedOutDate], [LastPasswordFailedDate], [LockedDate], [LoginId], [PasswordFailureAttemptCount], [PasswordHash], [PersonNo], [SubmittedDate], [SubmittedPerson], [UpdatedDate], [UpdatedPerson], [UserGroupNo], [UserId], [UserRoleNo])
VALUES (CAST(1 AS smallint), NULL, NULL, '2024-12-17T20:31:15.7787099+08:00', CAST(90 AS smallint), NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, CAST(1 AS bit), NULL, NULL, NULL, NULL, '', NULL, 'MjZALnvidPPUogKCJ8w9wg==', 1, NULL, NULL, NULL, NULL, CAST(0 AS smallint), 'ADMIN', CAST(0 AS smallint));
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserNo', N'ApprovedDate', N'ApprovedPerson', N'CreatedDate', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'Email', N'EmployeeNo', N'ExpirationDate', N'IsApproved', N'IsLoggedOn', N'IsSubmitted', N'IsSystemPredefined', N'LastLoggedOnDate', N'LastLoggedOutDate', N'LastPasswordFailedDate', N'LockedDate', N'LoginId', N'PasswordFailureAttemptCount', N'PasswordHash', N'PersonNo', N'SubmittedDate', N'SubmittedPerson', N'UpdatedDate', N'UpdatedPerson', N'UserGroupNo', N'UserId', N'UserRoleNo') AND [object_id] = OBJECT_ID(N'[common].[User]'))
    SET IDENTITY_INSERT [common].[User] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserNo', N'AppExpirationDate', N'AppUserGroupNo', N'AppUserRoleNo', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'UpdatedDate', N'UpdatedPerson') AND [object_id] = OBJECT_ID(N'[psi].[AppUser]'))
    SET IDENTITY_INSERT [psi].[AppUser] ON;
GO

INSERT INTO [psi].[AppUser] ([UserNo], [AppExpirationDate], [AppUserGroupNo], [AppUserRoleNo], [CreatedPerson], [DeletedDate], [DeletedPerson], [UpdatedDate], [UpdatedPerson])
VALUES (CAST(1 AS smallint), NULL, CAST(0 AS smallint), CAST(0 AS smallint), CAST(0 AS smallint), NULL, NULL, NULL, NULL);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserNo', N'AppExpirationDate', N'AppUserGroupNo', N'AppUserRoleNo', N'CreatedPerson', N'DeletedDate', N'DeletedPerson', N'UpdatedDate', N'UpdatedPerson') AND [object_id] = OBJECT_ID(N'[psi].[AppUser]'))
    SET IDENTITY_INSERT [psi].[AppUser] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241217123118_Initial', N'9.0.0');
GO

COMMIT;
GO
