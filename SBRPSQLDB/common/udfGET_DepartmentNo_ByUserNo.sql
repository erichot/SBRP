CREATE FUNCTION [common].[udfGET_DepartmentNo_ByUserNo]
(
	@UserNo SMALLINT,
	@WorkDate DATE = NULL
)
RETURNS  SMALLINT
AS
BEGIN
	DECLARE	@EmployeeNo SMALLINT
	SELECT @EmployeeNo = EmployeeNo
	FROM [common].[User] AS U WITH (NOLOCK)
	WHERE UserNo = @UserNo	

	RETURN [common].[udfGET_DepartmentNo_ByEmployeeNo](@EmployeeNo, @WorkDate)
END
