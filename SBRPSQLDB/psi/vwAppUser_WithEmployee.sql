CREATE VIEW [psi].[vwAppUser_WithEmployee]
	AS 
	
	SELECT 
		AU.IsAppReadonly,
		AU.IsAppDisabled,
		
		U.*	
	FROM [psi].[AppUser] AS AU
		INNER JOIN [common].[vwUser_WithEmployee] AS U
			ON AU.UserNo = U.UserNo
	
	
