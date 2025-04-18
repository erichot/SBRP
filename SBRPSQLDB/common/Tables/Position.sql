CREATE TABLE [common].[Position] (
    [PositionNo] smallint NOT NULL DEFAULT (NEXT VALUE FOR common.seqPosition),
    [SIGNo] tinyint NOT NULL DEFAULT (0),
    [PositionId] CHAR(12) NULL,
    [PositionName] nvarchar(24) NOT NULL,
    [PositionNameAbbr] nvarchar(8) NOT NULL,
    [IsSystemPredefined] bit NOT NULL DEFAULT (0),
    [IsDisabled] bit NOT NULL DEFAULT (0),
    [Remark] nvarchar(48) NULL,
    [IsDeleted] bit NOT NULL DEFAULT (0),
    [CreatedPerson] smallint NOT NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedPerson] smallint NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedPerson] smallint NULL,
    [DeletedDate] datetime2 NULL,
    [IsSubmitted] bit NULL,
    [SubmittedPerson] smallint NULL,
    [SubmittedDate] datetime2 NULL,
    [IsApproved] bit NULL,
    [ApprovedPerson] smallint NULL,
    [ApprovedDate] datetime2 NULL,
    CONSTRAINT [PK_Position] PRIMARY KEY ([PositionNo])
);
GO
CREATE INDEX [IX_Position_PositionId] ON [common].[Position] ([PositionId]);