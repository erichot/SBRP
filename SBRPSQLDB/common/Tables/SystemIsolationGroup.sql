CREATE TABLE [common].[SystemIsolationGroup] (
    [SIGNo] tinyint NOT NULL DEFAULT (NEXT VALUE FOR common.seqSystemIsolationGroup),
    [SIGId] CHAR(12) NOT NULL,
    [SIGName] nvarchar(24) NOT NULL,
    [CompanyNo] smallint NOT NULL,
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
    CONSTRAINT [PK_SystemIsolationGroup] PRIMARY KEY ([SIGNo])
);
GO
CREATE UNIQUE INDEX [IX_SystemIsolationGroup_SIGId] ON [common].[SystemIsolationGroup] ([SIGId]);