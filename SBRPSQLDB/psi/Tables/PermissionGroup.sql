CREATE TABLE [psi].[PermissionGroup] (
    [PermissionGroupNo] smallint NOT NULL DEFAULT (NEXT VALUE FOR psi.seqPermissionGroup),
    [SIGNo] tinyint NOT NULL,
    [PermissionGroupId] CHAR(24) NULL,
    [PermissionGroupName] nvarchar(16) NOT NULL,
    [DepartmentNo] smallint NULL,
    [PositionNo] smallint NULL,
    [IsSystemPredefined] bit NOT NULL DEFAULT (0),
    [IsInvisible] bit NOT NULL DEFAULT (0),
    [IsDisabled] bit NOT NULL DEFAULT (0),
    [Remark] nvarchar(48) NULL,
    [IsDeleted] bit NOT NULL DEFAULT (0),
    [CreatedPerson] smallint NOT NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedPerson] smallint NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedPerson] smallint NULL,
    [DeletedDate] datetime2 NULL,
    CONSTRAINT [PK_PermissionGroup] PRIMARY KEY ([PermissionGroupNo]),
    CONSTRAINT [FK_PermissionGroup_Department_DepartmentNo] FOREIGN KEY ([DepartmentNo]) REFERENCES [common].[Department] ([DepartmentNo]),
    CONSTRAINT [FK_PermissionGroup_Position_PositionNo] FOREIGN KEY ([PositionNo]) REFERENCES [common].[Position] ([PositionNo])
);
GO
CREATE INDEX [IX_PermissionGroup_DepartmentNo] ON [psi].[PermissionGroup] ([DepartmentNo]);
GO
CREATE INDEX [IX_PermissionGroup_PermissionGroupId] ON [psi].[PermissionGroup] ([PermissionGroupId]);
GO
CREATE INDEX [IX_PermissionGroup_PositionNo] ON [psi].[PermissionGroup] ([PositionNo]);