CREATE TABLE [psi].[MenuitemSIG] (
    [NodeNo] smallint NOT NULL,
    [SIGNo] tinyint NOT NULL,
    [NodeName] nvarchar(16) NULL,
    [OrderNo] smallint NULL,
    [IsInvisible] bit NULL,
    [IsDisabled] bit NULL,
    [CreatedPerson] smallint NOT NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedPerson] smallint NULL,
    [UpdatedDate] datetime2 NULL,
    CONSTRAINT [PK_MenuitemSIG] PRIMARY KEY ([NodeNo], [SIGNo]),
    CONSTRAINT [FK_MenuitemSIG_Menuitem_NodeNo] FOREIGN KEY ([NodeNo]) REFERENCES [psi].[Menuitem] ([NodeNo]) ON DELETE CASCADE
);