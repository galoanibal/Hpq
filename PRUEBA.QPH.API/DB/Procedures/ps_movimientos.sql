USE [Prueba_QPH_Galo_Baque]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'ps_movimientos')
	DROP PROC dbo.ps_movimientos
GO 

CREATE PROCEDURE [dbo].[ps_movimientos]
	@accion [char](1),
	@id_cuenta		[int]				= null,	
	@fecha			[datetime]			= null,
	@fecha_fin		[datetime]			= null,
	@tipo			[varchar](10)		= null,	
	@valor			[decimal](18, 2)	= null,
	@offset			[int]				= null,
	@limit			[int]				= null
WITH EXECUTE AS CALLER
AS
IF @accion = 'I'
BEGIN
	BEGIN TRANSACTION  
		INSERT	INTO [dbo].[Movimientos]
			   ([IdCuenta]
				  ,[Fecha]
				  ,[Tipo]
				  ,[Valor])
		VALUES (
				@id_cuenta	,
				@fecha ,
				@tipo,
				@valor)
	IF(@@ERROR > 0)  
		BEGIN  
			ROLLBACK TRANSACTION  
		END  
		ELSE  
		BEGIN  
		   COMMIT TRANSACTION  
		END
	select IdMovimiento= SCOPE_IDENTITY()

	RETURN 0
END

IF @accion = 'L'
BEGIN
	SELECT	total_registros			= COUNT(1)
		FROM	[dbo].[Movimientos] m
		WHERE CAST(m.Fecha AS date) between CAST(@fecha AS date) and CAST(@fecha_fin AS date)
		
	SELECT	*
		FROM	[dbo].[Movimientos] m WITH(NOLOCK)
		WHERE CAST(m.Fecha AS date) between CAST(@fecha AS date) and CAST(@fecha_fin AS date)
		ORDER	BY m.IdMovimiento
		OFFSET	(@offset - 1) ROWS
		FETCH	NEXT @limit ROWS ONLY
	
	RETURN 0
END

RAISERROR ('El código de la acción es incorrecto.',16,1)

