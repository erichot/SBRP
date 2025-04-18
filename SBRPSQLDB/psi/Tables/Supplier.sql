CREATE TABLE [psi].[Supplier] (
    [SupplierNo] smallint NOT NULL DEFAULT (NEXT VALUE FOR psi.seqSupplier),
    [SIGNo] tinyint NOT NULL DEFAULT (0),
    [CompanyNo] smallint NOT NULL,
    [SupplierId] CHAR(16) NULL,
    [SupplierName] nvarchar(32) NOT NULL,
    [SupplierNameAbbr] nvarchar(12) NOT NULL,
    [BillingPeriodType] tinyint NULL,
    [BillingPeriodDay] tinyint NULL,
    [PaymentPeriodType] tinyint NULL,
    [PaymentPeriodDay] tinyint NULL,
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
    CONSTRAINT [PK_Supplier] PRIMARY KEY ([SupplierNo]),
    CONSTRAINT [FK_Supplier_Company_CompanyNo] FOREIGN KEY ([CompanyNo]) REFERENCES [common].[Company] ([CompanyNo]) ON DELETE CASCADE
);
GO
CREATE INDEX [IX_Supplier_CompanyNo] ON [psi].[Supplier] ([CompanyNo]);
GO
CREATE INDEX [IX_Supplier_SupplierId] ON [psi].[Supplier] ([SupplierId]);