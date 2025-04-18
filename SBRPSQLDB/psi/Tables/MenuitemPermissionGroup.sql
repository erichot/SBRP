CREATE TABLE [psi].[MenuitemPermissionGroup] (
    [NodeNo] smallint NOT NULL,
    [PermissionGroupNo] smallint NOT NULL,
    [IsReadonly] bit NOT NULL DEFAULT (0),
    [CreatedPerson] smallint NOT NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedPerson] smallint NULL,
    [UpdatedDate] datetime2 NULL,
    CONSTRAINT [PK_MenuitemPermissionGroup] PRIMARY KEY ([NodeNo], [PermissionGroupNo]),
    CONSTRAINT [FK_MenuitemPermissionGroup_Menuitem_NodeNo] FOREIGN KEY ([NodeNo]) REFERENCES [psi].[Menuitem] ([NodeNo]) ON DELETE CASCADE,
    CONSTRAINT [FK_MenuitemPermissionGroup_PermissionGroup_PermissionGroupNo] FOREIGN KEY ([PermissionGroupNo]) REFERENCES [psi].[PermissionGroup] ([PermissionGroupNo]) ON DELETE CASCADE
);
GO
CREATE INDEX [IX_MenuitemPermissionGroup_PermissionGroupNo] ON [psi].[MenuitemPermissionGroup] ([PermissionGroupNo]);