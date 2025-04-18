CREATE TABLE [psi].[Menuitem] (
    [NodeNo] smallint NOT NULL DEFAULT (NEXT VALUE FOR psi.seqMenuitem),
    [NodeId] CHAR(8) NOT NULL,
    [HasChildNode] bit NOT NULL,
    [ParentNodeId] CHAR(8) NULL,
    [NodeName] nvarchar(16) NOT NULL,
    [AspPage] VARCHAR(48) NOT NULL,
    [AspController] VARCHAR(16) NULL,
    [AspAction] VARCHAR(16) NULL,
    [AspRouteNo] smallint NOT NULL,
    [DataFeather] VARCHAR(16) NOT NULL,
    [ItemDescription] nvarchar(64) NULL,
    [ThresholdPermissionValue] smallint NOT NULL,
    [RoleTypeFlag] tinyint NOT NULL,
    [OrderNo] smallint NOT NULL,
    [Version] VARCHAR(8) NOT NULL,
    [Remark] nvarchar(32) NULL,
    [IsIsolated] bit NOT NULL DEFAULT (0),
    [IsInvisible] bit NOT NULL DEFAULT (0),
    [IsDisabled] bit NOT NULL DEFAULT (0),
    [CreatedDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedDate] datetime2 NULL,
    CONSTRAINT [PK_Menuitem] PRIMARY KEY ([NodeNo])
);
GO
CREATE UNIQUE INDEX [IX_Menuitem_NodeId] ON [psi].[Menuitem] ([NodeId]);