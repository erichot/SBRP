

CREATE TABLE [psi].[ProductGeneralCategoryDefinition](
	[PGCategoryNo] [tinyint] NOT NULL,
	[PGCategoryId] [char](16) NOT NULL,
	[SIGNo] [tinyint] NOT NULL,
	[PGCategoryName] [nvarchar](16) NOT NULL,
	[ItemIdMinLength] [tinyint] NOT NULL,
	[ItemIdMaxLength] [tinyint] NOT NULL,
	[PGCOrderNo] [smallint] NOT NULL,
	[IsSystemPredefined] [bit] NOT NULL,
	[IsInvisible] [bit] NOT NULL,
	[IsDisabled] [bit] NOT NULL,
	[Remark] [nvarchar](48) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedPerson] [smallint] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedPerson] [smallint] NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[DeletedPerson] [smallint] NULL,
	[DeletedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_ProductGeneralCategoryDefinition] PRIMARY KEY CLUSTERED 
(
	[PGCategoryNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
