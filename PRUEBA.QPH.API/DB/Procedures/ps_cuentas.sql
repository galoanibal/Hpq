USE [Prueba_QPH_Galo_Baque]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'ps_cuentas')
	DROP PROC dbo.ps_cuentas
GO 

CREATE PROCEDURE [dbo].[ps_cuentas]
	@accion [char](1),
	@id_cuenta		[int]				= null,
	@id_cliente		[int]				= null,	
	@numero_cuenta	[varchar](10)		= null,
	@saldo			[decimal](18, 2)	= null,	
	@estado			[bit]				= null,
	@offset			[int]				= null,
	@limit			[int]				= null
WITH EXECUTE AS CALLER
AS
IF @accion = 'I'
BEGIN
	BEGIN TRANSACTION  
		INSERT	INTO [dbo].[Cuentas]
			   ([IdCliente]
			   ,[NumeroCuenta]			  
			   ,[Saldo]			   
			   ,[Estado])
		VALUES (
				@id_cliente	,
				@numero_cuenta ,
				@saldo,
				@estado)
	IF(@@ERROR > 0)  
		BEGIN  
			ROLLBACK TRANSACTION  
		END  
		ELSE  
		BEGIN  
		   COMMIT TRANSACTION  
		END
	select IdCuenta= SCOPE_IDENTITY()

	RETURN 0
END

IF @accion = 'M'
BEGIN
	BEGIN TRANSACTION  
		UPDATE [dbo].[Cuentas]
			   SET [IdCliente]=@id_cliente
				   ,[NumeroCuenta]=@numero_cuenta				  
				   ,[Saldo]=@saldo				  
				WHERE IdCuenta=@id_cuenta

		IF(@@ERROR > 0)  
		BEGIN  
			ROLLBACK TRANSACTION  
		END  
		ELSE  
		BEGIN  
		   COMMIT TRANSACTION  
		END 
	select IdCuenta=@id_cuenta
	RETURN 0
END

IF @accion = 'E'
BEGIN
	BEGIN TRANSACTION  
		UPDATE [dbo].[Cuentas]
			   SET [Estado]=@estado
				WHERE IdCuenta=@id_cuenta

		IF(@@ERROR > 0)  
		BEGIN  
			ROLLBACK TRANSACTION  
		END  
		ELSE  
		BEGIN  
		   COMMIT TRANSACTION  
		END 
	select IdCuenta=@id_cuenta
	RETURN 0
END

IF @accion = 'L'
BEGIN
	SELECT	total_registros			= COUNT(1)
		FROM	[dbo].[Cuentas] c
		WHERE c.Estado=1
	
	SELECT	*
		FROM	[dbo].[Cuentas] c WITH(NOLOCK)
		WHERE c.Estado=1
		ORDER	BY c.IdCuenta
		OFFSET	(@offset - 1) ROWS
		FETCH	NEXT @limit ROWS ONLY
	
	RETURN 0
END

IF @accion = 'C'
BEGIN	
	SELECT	*
		FROM	[dbo].[Cuentas] c WITH(NOLOCK)
		WHERE c.Estado=1 AND c.IdCliente=@id_cliente
		ORDER	BY c.IdCuenta
		
	
	RETURN 0
END

RAISERROR ('El código de la acción es incorrecto.',16,1)

