/*
Created date:	2024/12/17
*/
CREATE FUNCTION [common].[euPermssionGroupId_AllUsers]
(
)
RETURNS CHAR(24)
AS
BEGIN
	RETURN '_PG_ALL_'
END
