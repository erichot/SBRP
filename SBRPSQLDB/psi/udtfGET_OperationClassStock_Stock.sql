/*
Create: 2025/02/18
Remark: 

*/

CREATE FUNCTION [psi].[udtfGET_OperationClassStock_Stock]
(
	@OperationClassNo TINYINT,
	@SIGNo TINYINT,
	@UserNo SMALLINT
)
RETURNS TABLE
AS
RETURN
(

	SELECT 
		S.*
	FROM [psi].[OperationClassStock] AS O
		INNER JOIN [psi].[Stock] AS S
			ON O.StockNo = S.StockNo
		

	WHERE 	
		(O.OperationClassNo = @OperationClassNo)
		AND (S.SIGNo = @SIGNo)
)
