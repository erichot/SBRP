CREATE TABLE [common].[Employee] (
    [EmployeeNo] smallint NOT NULL IDENTITY,
    [SIGNo] tinyint NOT NULL DEFAULT (0),
    [EmployeeId] CHAR(16) NULL,
    [PersonNo] int NOT NULL DEFAULT (NEXT VALUE FOR common.seqEmployee),
    [PositionNo] smallint NULL,
    [StartDate] date NULL,
    [EndDate] date NULL,
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
    CONSTRAINT [PK_Employee] PRIMARY KEY ([EmployeeNo]),
    CONSTRAINT [FK_Employee_Person_PersonNo] FOREIGN KEY ([PersonNo]) REFERENCES [common].[Person] ([PersonNo]) ON DELETE CASCADE
);
GO
CREATE INDEX [IX_Employee_EmployeeId] ON [common].[Employee] ([EmployeeId]);
GO
CREATE INDEX [IX_Employee_PersonNo] ON [common].[Employee] ([PersonNo]);