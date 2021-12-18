﻿CREATE PROCEDURE [dbo].[ProductoInsertar]
	@Descripcion VARCHAR(500),
    @Estado BIT
	
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

		
		INSERT INTO dbo.Producto
		(	       
	      Descripcion,
		  Estado
		)
		VALUES
		(
		
	      @Descripcion,
		  @Estado
		)


		COMMIT TRANSACTION TRASA
		
		SELECT 0 AS CodeError, '' AS MsgError



	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END