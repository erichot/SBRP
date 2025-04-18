CREATE TABLE [common].[UserLoginHistory] (
    [UserLoginHistoryNo] int NOT NULL IDENTITY,
    [LoginId] VARCHAR(32) NULL,
    [AppId] tinyint NOT NULL,
    [RemoteIpAddress] VARCHAR(50) NULL,
    [IsAccountDisabled] bit NOT NULL,
    [HasBeenLocked] bit NOT NULL,
    [IsLoginSuccessful] bit NOT NULL,
    [LoginActionNo] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT [PK_UserLoginHistory] PRIMARY KEY ([UserLoginHistoryNo])
);