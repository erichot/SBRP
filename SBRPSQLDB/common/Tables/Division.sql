CREATE TABLE [common].[Division] (
    [DivisionNo] smallint NOT NULL DEFAULT (NEXT VALUE FOR common.seqDivisionNo),
    [SIGNo] tinyint NOT NULL DEFAULT (0),
    [DivisionId] nvarchar(450) NULL,
    [DivisionName] nvarchar(24) NOT NULL,
    [DivisionNameAbbr] nvarchar(8) NOT NULL,
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
    [IsSubmitted] bit NULL,
    [SubmittedPerson] smallint NULL,
    [SubmittedDate] datetime2 NULL,
    [IsApproved] bit NULL,
    [ApprovedPerson] smallint NULL,
    [ApprovedDate] datetime2 NULL,
    CONSTRAINT [PK_Division] PRIMARY KEY ([DivisionNo])
);
GO
CREATE INDEX [IX_Division_DivisionId] ON [common].[Division] ([DivisionId]);