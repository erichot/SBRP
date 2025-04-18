CREATE TABLE [psi].[AppUser] (
    [UserNo] smallint NOT NULL,
    [AppUserGroupNo] smallint NOT NULL,
    [AppUserRoleNo] smallint NOT NULL,
    [IsAppReadonly] bit NOT NULL DEFAULT (0),
    [IsAppDisabled] bit NOT NULL DEFAULT (0),
    [AppExpirationDate] date NULL,
    [CreatedPerson] smallint NOT NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedPerson] smallint NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedPerson] smallint NULL,
    [DeletedDate] datetime2 NULL,
    CONSTRAINT [PK_AppUser] PRIMARY KEY ([UserNo]),
    CONSTRAINT [FK_AppUser_User_UserNo] FOREIGN KEY ([UserNo]) REFERENCES [common].[User] ([UserNo]) ON DELETE CASCADE
);