CREATE TABLE [common].[UserPasswordHistory] (
    [HistoryNo] int NOT NULL IDENTITY,
    [UserNo] smallint NOT NULL,
    [Password] VARCHAR(128) NULL,
    [LoginActionNo] int NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT [PK_UserPasswordHistory] PRIMARY KEY ([HistoryNo])
);
GO
CREATE INDEX [IX_UserPasswordHistory_UserNo] ON [common].[UserPasswordHistory] ([UserNo]);