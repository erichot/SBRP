CREATE TABLE [common].[Person] (
    [PersonNo] int NOT NULL DEFAULT (NEXT VALUE FOR common.seqEmployee),
    [PersonId] CHAR(16) NULL,
    [SIGNo] tinyint NOT NULL DEFAULT (0),
    [PersonName] nvarchar(40) NOT NULL,
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
    CONSTRAINT [PK_Person] PRIMARY KEY ([PersonNo])
);
GO
CREATE INDEX [IX_Person_PersonId] ON [common].[Person] ([PersonId]);