--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[common].[INSERT_SystemIsolationGroup_SIGWithRelateDefault]') AND type in (N'P', N'PC'))
--DROP PROCEDURE [common].[INSERT_SystemIsolationGroup_SIGWithRelateDefault]
--GO
/*
Created:	2024/12/15
Parameter:	
	@SIGNo = 0	則表示為單一客戶使用
Remark:		執行順序：由中心（common）往外擴充執行（ex:PSI），代表客戶的預先基礎資料在各APP都預先建立
*/
CREATE  PROCEDURE [common].[uspINSERT_SystemIsolationGroup_SIGWithRelateDefault]
	@SIGNo tinyint = 0
AS
	DECLARE @CreatedPerson SMALLINT = 90
	DECLARE @AffectedRows INT = 0
	DECLARE @AffectedRows_temp INT
	SET @SIGNo = ISNULL(@SIGNo, 0)
		
	

	DECLARE @CompanyNo SMALLINT = CAST(@SIGNo AS SMALLINT)
	DECLARE @DepartmentNo SMALLINT = CAST(@SIGNo AS SMALLINT)

	DECLARE @IsSystemPredefined BIT = 1
	DECLARE @IsDisabled BIT = 1

	BEGIN TRANSACTION
		
	BEGIN TRY
		IF @SIGNo = 0
			BEGIN
				IF NOT EXISTS (
					SELECT * FROM [common].[SystemIsolationGroup] WHERE SIGNo = @SIGNo
					)
					BEGIN
						INSERT [common].[SystemIsolationGroup]	
								(SIGNo, SIGId, SIGName, CompanyNo, IsSystemPredefined, Remark, CreatedPerson)
						VALUES (@SIGNo, 'DEFAULT', 'Default SIG', @CompanyNo,  1, 'Only one SIG', @CreatedPerson)
						SET @AffectedRows = @AffectedRows + @@ROWCOUNT
					END
			END



		-- ============================================================
		EXEC @AffectedRows_temp = [psi].[uspINSERT_SystemIsolationGroup_SIGWithRelateDefault]
			@SIGNo = @SIGNo

		SET @AffectedRows = @AffectedRows + @@ROWCOUNT


		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;

        -- Get error details
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        -- Print or log error details
        PRINT 'Error occurred: ' + @ErrorMessage;

        -- Optionally, re-throw the error to be handled by the calling code
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH



	




	
RETURN @AffectedRows
