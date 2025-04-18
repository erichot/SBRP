CREATE FUNCTION [psi].[udtfGET_PermissionGroup_ByUser]
(
	@SIGNo TINYINT,
	@UserNo SMALLINT
)
RETURNS TABLE AS RETURN
(
	-- 傳回該User所屬的安全性群組的資料清單
	SELECT
		PG.[PermissionGroupNo]
		 ,PG.[SIGNo]
		  ,PG.[PermissionGroupName]
		  ,PG.[DepartmentNo]
		  ,PG.[PositionNo]
		  ,PG.[IsSystemPredefined]
		  ,PG.[IsInvisible]
		  ,PG.[Remark]

	FROM [psi].[PermissionGroup] AS PG
		-- 職務：從User清單，取得單筆指定User資料（目前系統規格一個人只會有一個職務）
		LEFT JOIN [psi].[vwAppUser_WithEmployee] AS U
			ON  U.UserNo = @UserNo
				AND PG.PositionNo = U.PositionNo

	WHERE PG.IsDeleted = 0 AND PG.IsDisabled = 0		
		AND (ISNULL(@SIGNo, 0) = 0 OR PG.SIGNo =@SIGNo)
		AND
		-- 找尋該User所屬的部門 & 職務
		(
			(
				(PG.DepartmentNo IS NOT NULL AND PG.DepartmentNo = [common].[udfGET_DepartmentNo_ByUserNo](@UserNo, NULL))
				OR
				(PG.PositionNo IS NOT NULL AND PG.PositionNo = U.PositionNo)
			)
			OR
			-- 若該群組為Everyone
			PG.PermissionGroupId = [common].[euPermssionGroupId_AllUsers]()
		)
)
