CREATE TABLE [common].[CompanyContactPerson] (
    [CompanyNo] smallint NOT NULL,
    [ContactItemNo] smallint NOT NULL,
    [PersonNo] int NULL,
    [Title] nvarchar(16) NOT NULL,
    [ContactName] nvarchar(16) NULL,
    [ContactAddress] nvarchar(64) NULL,
    [ContactPhone] VARCHAR(16) NULL,
    [MobilePhone] VARCHAR(16) NULL,
    [EmailAddress] VARCHAR(64) NULL,
    [Remark] nvarchar(48) NULL,
    [IsDeleted] bit NOT NULL DEFAULT (0),
    [CreatedPerson] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedPerson] int NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedPerson] int NULL,
    [DeletedDate] datetime2 NULL,
    CONSTRAINT [PK_CompanyContactPerson] PRIMARY KEY ([CompanyNo], [ContactItemNo]),
    CONSTRAINT [FK_CompanyContactPerson_Company_CompanyNo] FOREIGN KEY ([CompanyNo]) REFERENCES [common].[Company] ([CompanyNo]) ON DELETE CASCADE,
    CONSTRAINT [FK_CompanyContactPerson_Person_PersonNo] FOREIGN KEY ([PersonNo]) REFERENCES [common].[Person] ([PersonNo])
);
GO
CREATE INDEX [IX_CompanyContactPerson_PersonNo] ON [common].[CompanyContactPerson] ([PersonNo]);