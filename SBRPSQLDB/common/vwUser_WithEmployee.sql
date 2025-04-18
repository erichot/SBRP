CREATE VIEW [common].[vwUser_WithEmployee]
	AS 
	
		SELECT 
				U.UserNo,
				U.SIGNo,
				U.UserId,
				U.EmployeeNo,
				U.PersonNo,
				U.LoginId,
				U.PasswordHash,
				U.Email,
				U.IsReadonly,
				U.IsDisabled,

				P.PersonId,
				P.PersonName,

				E.PositionNo
		FROM [common].[User] AS U
			INNER JOIN [common].[Person] AS P
				ON U.PersonNo = P.PersonNo
			LEFT JOIN [common].[Employee] AS E
				ON U.EmployeeNo = E.EmployeeNo
