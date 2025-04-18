/*

Remark:		員工部門歸屬，由於有起訖日的時間序，故有多筆明細資料須篩選
					另系統另提供每日或非即時寫入員工當下狀態to一份員工當下資料表，記錄這類起訖日的生效狀況
					當下狀態 => 可快速查表
					明細各階段狀態 => 查詢明細資料表
*/
CREATE FUNCTION [common].[udfGET_DepartmentNo_ByEmployeeNo]
(
	@EmployeeNo SMALLINT,
	@WorkDate DATE = NULL
)
RETURNS SMALLINT
AS
BEGIN
	DECLARE @DepartmentNo SMALLINT 


	IF ISNULL(@EmployeeNo, 0) = 0 
		RETURN NULL




	SELECT 
		TOP 1  
		@DepartmentNo = 	DE.DepartmentNo
	FROM [common].[User] AS U WITH (NOLOCK)
		-- User操作人員有可能是員工，但員工不一定是操作人員
		INNER JOIN [common].[Employee] AS E WITH (NOLOCK)
			ON U.EmployeeNo = E.EmployeeNo AND U.IsDeleted = 0
		INNER JOIN [common].[DepartmentEmployee] AS DE WITH (NOLOCK)
			ON E.EmployeeNo = DE.EmployeeNo
				AND DE.IsDeleted = 0
	WHERE (
			E.EmployeeNo = @EmployeeNo
			AND
			(
				-- 查詢日期小於任職日
				(DE.StartDate IS NULL OR DE.StartDate <= ISNULL(@WorkDate, CAST(GETDATE() AS DATE)))
				AND 
				-- 查詢日小於離職日
				(DE.EndDate IS NULL OR ISNULL(@WorkDate, CAST(GETDATE() AS DATE)) <= DE.EndDate)
			)
		)
	ORDER BY DE.StartDate DESC

	RETURN @DepartmentNo
END
