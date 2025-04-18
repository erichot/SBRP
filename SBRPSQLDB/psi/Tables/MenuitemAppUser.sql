CREATE TABLE [psi].[MenuitemAppUser] (
    [NodeNo] smallint NOT NULL,
    [AppUserNo] smallint NOT NULL,
    [IsReadonly] bit NOT NULL,
    [CreatedPerson] smallint NOT NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedPerson] smallint NULL,
    [UpdatedDate] datetime2 NULL,
    CONSTRAINT [PK_MenuitemAppUser] PRIMARY KEY ([NodeNo], [AppUserNo]),
    CONSTRAINT [FK_MenuitemAppUser_AppUser_AppUserNo] FOREIGN KEY ([AppUserNo]) REFERENCES [psi].[AppUser] ([UserNo]) ON DELETE CASCADE,
    CONSTRAINT [FK_MenuitemAppUser_Menuitem_NodeNo] FOREIGN KEY ([NodeNo]) REFERENCES [psi].[Menuitem] ([NodeNo]) ON DELETE CASCADE
);
GO
CREATE INDEX [IX_MenuitemAppUser_AppUserNo] ON [psi].[MenuitemAppUser] ([AppUserNo]);