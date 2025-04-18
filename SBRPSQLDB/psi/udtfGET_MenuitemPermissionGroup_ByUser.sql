CREATE FUNCTION [psi].[udtfGET_MenuitemPermissionGroup_ByUser]
(
	@SIGNo TINYINT,
	@UserNo SMALLINT
)
RETURNS TABLE AS RETURN
(
	SELECT 
				DISTINCT
					MPG.NodeNo, MPG.IsReadonly
	FROM [psi].[MenuitemPermissionGroup] AS MPG
		INNER JOIN [psi].[udtfGET_PermissionGroup_ByUser](@SIGNo, @UserNo) AS PG						
			ON MPG.PermissionGroupNo = PG.PermissionGroupNo				
		
)
