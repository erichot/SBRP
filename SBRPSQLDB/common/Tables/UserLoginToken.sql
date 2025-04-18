CREATE TABLE [common].[UserLoginToken] (
    [IssuedDate] date NOT NULL,
    [UserNo] smallint NOT NULL,
    [SerialNo] tinyint NOT NULL,
    [LoginActionNo] int NOT NULL IDENTITY,
    [WebToken] CHAR(32) NOT NULL,
    [AppId] tinyint NOT NULL,
    [RemoteIpAddress] VARCHAR(50) NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [ExpiredDate] datetime2 NULL,
    [InValid] bit NOT NULL DEFAULT (0),
    [InvalidDate] datetime2 NULL,
    CONSTRAINT [PK_UserLoginToken] PRIMARY KEY ([IssuedDate], [UserNo], [SerialNo]),
    CONSTRAINT [FK_UserLoginToken_User_UserNo] FOREIGN KEY ([UserNo]) REFERENCES [common].[User] ([UserNo]) ON DELETE CASCADE
);
GO
CREATE INDEX [IX_UserLoginToken_UserNo] ON [common].[UserLoginToken] ([UserNo]);
GO
CREATE INDEX [IX_UserLoginToken_WebToken] ON [common].[UserLoginToken] ([WebToken]);