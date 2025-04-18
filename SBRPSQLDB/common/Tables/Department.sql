CREATE TABLE [common].[Department] (
    [DepartmentNo] smallint NOT NULL DEFAULT (NEXT VALUE FOR common.seqDepartment),
    [SIGNo] tinyint NOT NULL DEFAULT (0),
    [DepartmentId] nvarchar(450) NULL,
    [DepartmentName] nvarchar(24) NOT NULL,
    [DepartmentNameAbbr] nvarchar(8) NOT NULL,
    [DivisionNo] smallint NULL,
    [ParentDepartmentNo] smallint NULL,
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
    CONSTRAINT [PK_Department] PRIMARY KEY ([DepartmentNo]),
    CONSTRAINT [FK_Department_Department_ParentDepartmentNo] FOREIGN KEY ([ParentDepartmentNo]) REFERENCES [common].[Department] ([DepartmentNo]),
    CONSTRAINT [FK_Department_Division_DivisionNo] FOREIGN KEY ([DivisionNo]) REFERENCES [common].[Division] ([DivisionNo])
);
GO
CREATE INDEX [IX_Department_DepartmentId] ON [common].[Department] ([DepartmentId]);
GO
CREATE INDEX [IX_Department_DivisionNo] ON [common].[Department] ([DivisionNo]);
GO
CREATE INDEX [IX_Department_ParentDepartmentNo] ON [common].[Department] ([ParentDepartmentNo]);