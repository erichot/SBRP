/*
Create:		2025/03/30
Remark: 

*/

CREATE 
	--OR ALTER 
		PROCEDURE [psi].[uspGET_ProductStock_PivotReport]
	@SIGNo TINYINT 
	,@SearchKeywordArray NVARCHAR(500) = NULL
	,@StockNoFilterArray NVARCHAR(500) = NULL
	,@StockPriorityTypeNo TINYINT = 0
	,@StockNo SMALLINT = 0 
	,@UserNo SMALLINT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @ResultSql NVARCHAR(MAX) 
	
	-- Declare a table variable to hold the split values
	DECLARE @SplitValues TABLE (Value NVARCHAR(MAX));

	-- Use STRING_SPLIT to split the string and insert the values into the table variable
	INSERT INTO @SplitValues (Value)
	SELECT TRIM(value) -- TRIM is used to remove any leading or trailing spaces
	FROM STRING_SPLIT(@SearchKeywordArray, ',');


	DECLARE @tbl_Stock TABLE 
		(
			StockNo SMALLINT
		)

	DECLARE @PivotStockColumnGroup NVARCHAR(MAX), @PivotStockColumnAlias NVARCHAR(MAX), @PivotStockSubTotalColumn NVARCHAR(MAX)
	



	-- ================================================================
	DECLARE @SqlSelect_StocksColumns NVARCHAR(MAX) 
	DECLARE @ResultSqlFromLeftJoinStockArray NVARCHAR(MAX) 
	

	IF NOT OBJECT_ID('tempdb..#S') IS NULL
		DROP TABLE #S

	--CREATE TABLE #S (
	--	StockNo SMaLLINT,
	--	StockNoString NVARCHAR(6),
	--	StockId CHAR(16),
	--	StockIdString NVARCHAR(6),
	--	StockNameAbbr NVARCHAR(12),
	--	CONSTRAINT T_PK PRIMARY KEY (StockNo)
	--)

	;WITH CTE AS (
		SELECT 
			StockNo
			, StockId
			,CAST(StockNo AS NVARCHAR(6)) AS StockNoString			
			,'[PS_' + CAST(StockNo AS NVARCHAR(6)) + ']' AS TableNameAlias
			,'[' + StockNameAbbr + '存量]' AS StockQtyNameAlias
			,'[' + StockNameAbbr + '轉入]' AS InTransitQtyNameAlias
			,'[' + StockNameAbbr + '客訂]' AS PreOrderQtyNameAlias
			,'[' + StockNameAbbr + '可銷]' AS SellableQtyNameAlias
		FROM [psi].[Stock]
		WHERE IsDeleted = 0 AND IsLinkToStore = 1
	)
	SELECT 
			StockNo
			, '[psi].[ProductStock] AS ' + TableNameAlias  AS ProductStockTable
			, TableNameAlias + '.StockQty AS ' + StockQtyNameAlias  AS SelectColumn_StockQty
			, TableNameAlias + '.InTransitQty AS ' + InTransitQtyNameAlias  AS SelectColumn_InTransitQty
			, TableNameAlias + '.PreOrderQty AS ' + PreOrderQtyNameAlias  AS SelectColumn_PreOrderQty
			, TableNameAlias + '.SellableQty AS ' + SellableQtyNameAlias  AS SelectColumn_SellableQty
			, TableNameAlias + '.StockNo = ' + StockNoString AS OnConditionStockNo
			, 'P.ProductNo = ' + TableNameAlias + '.ProductNo' AS OnConditionProductNo
	INTO #S
	FROM CTE
	
	
	
	SELECT @SqlSelect_StocksColumns = 
		ISNULL(@SqlSelect_StocksColumns + ', ', '')  
			+ SelectColumn_StockQty + ', ' + SelectColumn_InTransitQty + ', ' + SelectColumn_PreOrderQty + ', ' +  SelectColumn_SellableQty 				
		
		,@ResultSqlFromLeftJoinStockArray =
			ISNULL(@ResultSqlFromLeftJoinStockArray, '')  +  ' LEFT JOIN ' + ProductStockTable + ' ON ' + OnConditionStockNo + ' AND  ' +  OnConditionProductNo + ' '
	FROM #S
	ORDER BY StockNo DESC

	SET @PivotStockSubTotalColumn = @PivotStockSubTotalColumn + ') AS [合計] '
	-- ==============================================================






	-- ===================================
	SET @ResultSql = N'
		SELECT P.ProductNo, CAST(RTRIM(P.ProductId) AS VARCHAR(32)) AS 貨號, P.ProductName AS 品名, ' + @SqlSelect_StocksColumns + '			
		FROM [psi].[Product] AS P  ' + @ResultSqlFromLeftJoinStockArray + ' WHERE P.IsDeleted = 0 '
	
	
	--SELECT @ResultSql
	EXEC sp_executesql  @ResultSql;

	RETURN @@ROWCOUNT
END
