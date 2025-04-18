/*
Create: 2024/12/29
Remark: 
	[ProductGeneralCategoryDefinition] 所引導出的Menu，其特性為不存在[Menuitem]，也不存在於[MenuitemSIG]
*/

CREATE FUNCTION [psi].[udtfGET_Menuitem_ByUserWithPermission]
(
	@SIGNo TINYINT,
	@UserNo SMALLINT
)
RETURNS TABLE
AS
RETURN
(

	SELECT 
		M.NodeNo
		  ,M.[NodeId]
		  ,M.[HasChildNode]
		  ,M.[ParentNodeId]
		  ,M.[NodeName]
		  ,M.[AspPage]
		  ,M.[AspController]
		  ,M.[AspAction]
		  ,M.[AspRouteNo]
		  ,M.[DataFeather]
		  ,M.[ItemDescription]
		  ,M.[ThresholdPermissionValue]
		  ,M.[RoleTypeFlag]
		  ,M.[OrderNo]
		  ,M.[Version]
		  ,M.[Remark]

			,M.[IsIsolated]
			,M.[IsInvisible]
			,M.[IsDisabled]
			,M.[CreatedDate]
			,M.[UpdatedDate]
	FROM [psi].[Menuitem] AS M
		INNER JOIN [psi].[MenuitemSIG] AS MSG
			ON M.NodeNo = MSG.NodeNo 
				AND (ISNULL(@SIGNo, 0) = 0 OR MSG.SIGNo =@SIGNo)

		-- 關聯 個人功能表設定
		LEFT JOIN [psi].[MenuitemAppUser] AS MAU
			ON M.NodeNo = MAU.NodeNo 
				AND MAU.AppUserNo = @UserNo	
		
		-- 關聯 群組功能表設定
		LEFT JOIN [psi].[udtfGET_MenuitemPermissionGroup_ByUser](@SIGNo, @UserNo) AS MPG
			ON M.NodeNo = MPG.NodeNo

	WHERE 	
		-- 個人功能表 or 群組功能表設定，二擇一，至少要有其一能關連並篩選出NodeNo
		(MAU.NodeNo IS NOT NULL OR MPG.NodeNo IS NOT NULL)
)
