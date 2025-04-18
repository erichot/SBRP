CREATE TRIGGER [psi].[trgSupplier_SupplierId]
ON [psi].[Supplier]
INSTEAD OF INSERT
AS
BEGIN
	SET NOCOUNT ON
	IF EXISTS (
		SELECT 1
		FROM [psi].[Supplier] AS S WITH (NOLOCK)
		JOIN inserted AS I ON S.SIGNo = I.SIGNo AND S.SupplierId = I.SupplierId
	)
	BEGIN
		 --RAISERROR ('Duplicate [SupplierId] for [Supplier]: %s %s', 16, 1, (SELECT SupplierId FROM inserted), (SELECT SupplierName FROM inserted));
		 RAISERROR ('Duplicate [SupplierId] for [Supplier]: %s %s', 16, 1);
	END
END
