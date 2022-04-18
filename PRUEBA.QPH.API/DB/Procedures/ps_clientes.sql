USE [Prueba_QPH_Galo_Baque]
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'ps_clientes')
	DROP PROC dbo.ps_clientes
GO
CREATE PROC dbo.ps_clientes (
	@accion			[char](1),
	@id_cliente		[int]			= null,
	@nombre			[varchar](100)	= null,
	@direccion		[varchar](200)	= null,
	@telefono		[varchar](15)	= null,
	@estado			[bit]			= null,
	@offset			[int]			= null,
	@limit			[int]			= null
)
AS

IF @accion = 'I'
BEGIN
	BEGIN TRANSACTION  
		INSERT	INTO [dbo].[Clientes]
			   ([Nombre]
			   ,[Direccion]	
			   ,[Telefono]
			   ,[Estado])
		VALUES (
				@nombre	,
				@direccion,				
				@telefono,
				@estado)
	IF(@@ERROR > 0)  
		BEGIN  
			ROLLBACK TRANSACTION  
		END  
		ELSE  
		BEGIN  
		   COMMIT TRANSACTION  
		END
	select IdCliente= SCOPE_IDENTITY()

	RETURN 0
END

IF @accion = 'M'
BEGIN
	BEGIN TRANSACTION  
		UPDATE [dbo].[Clientes]
			   SET [Nombre] = @nombre,
				   [Direccion] = @direccion,
				   [Telefono] = @telefono,
				   [Estado]=@estado
				WHERE IdCliente=@id_cliente

		IF(@@ERROR > 0)  
		BEGIN  
			ROLLBACK TRANSACTION  
		END  
		ELSE  
		BEGIN  
		   COMMIT TRANSACTION  
		END 
	select IdCliente=@id_cliente
	RETURN 0
END

IF @accion = 'E'
BEGIN
	BEGIN TRANSACTION  
		UPDATE [dbo].[Clientes]
			   SET [Estado]=@estado
				WHERE IdCliente=@id_cliente

		IF(@@ERROR > 0)  
		BEGIN  
			ROLLBACK TRANSACTION  
		END  
		ELSE  
		BEGIN  
		   COMMIT TRANSACTION  
		END 
	select IdCliente=@id_cliente
	RETURN 0
END

IF @accion = 'L'
BEGIN
	SELECT	total_registros			= COUNT(1)
		FROM	[dbo].[Clientes] c
		WHERE c.Estado=1
	
	SELECT	c.IdCliente,c.Nombre, IsNull(c.Direccion,'')as Direccion, ISNULL(c.Telefono, '')as Telefono, c.Estado
		FROM	[dbo].[Clientes] c WITH(NOLOCK)
		WHERE c.Estado=1
		ORDER	BY c.IdCliente
		OFFSET	(@offset - 1) ROWS
		FETCH	NEXT @limit ROWS ONLY
	
	RETURN 0
END

RAISERROR ('El código de la acción es incorrecto.',16,1)

