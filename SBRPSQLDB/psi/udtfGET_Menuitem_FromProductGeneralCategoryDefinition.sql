/*
Create: 2024/12/30
Remark: 
	[ProductGeneralCategoryDefinition] 所引導出的Menu，其特性為不存在[Menuitem]，也不存在於[MenuitemSIG]
	靜態資料：有存在於[Menuitem]，但只是一個Parent head
	動態資料：子child node的部分則透過[ProductGeneralCategoryDefinition]轉換
	轉換過程：子child並未擁有各自的屬性，透過複製（且共用Parent node）
*/

CREATE FUNCTION [psi].[udtfGET_Menuitem_FromProductGeneralCategoryDefinition]
(
	@SIGNo TINYINT,
	@UserNo SMALLINT
)
RETURNS TABLE
AS
RETURN
(
	WITH CTE AS (
		SELECT *
		FROM [psi].[udtfGET_Menuitem_ByUserWithPermission](@SIGNo, @UserNo)
		WHERE NodeNo = 400
	)
	SELECT 
	    CAST(M.NodeNo * 10 + GCD.PGCategoryNo AS SMALLINT) AS [NodeNo]
      ,GCD.PGCategoryId AS [NodeId]
      ,CAST(0 AS BIT) AS [HasChildNode]
      ,M.NodeId AS [ParentNodeId]
      ,GCD.PGCategoryName AS [NodeName]
      ,M.AspPage AS [AspPage]
      ,M.AspController AS [AspController]
      ,M.AspAction AS [AspAction]
      ,CAST(GCD.PGCategoryNo AS SMALLINT) AS [AspRouteNo]
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
	FROM [psi].[ProductGeneralCategoryDefinition] AS GCD
		, CTE AS M
	WHERE GCD.SIGNo = @SIGNo
		AND GCD.IsInvisible = 0
		AND GCD.IsDisabled = 0
		AND GCD.IsDeleted = 0
)
