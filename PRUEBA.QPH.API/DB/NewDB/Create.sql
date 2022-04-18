/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2019 (15.0.4153)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2019
    Target Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [master]
GO
/****** Object:  Database [Prueba_QPH_Galo_Baque]    Script Date: 17/4/2022 20:30:37 ******/
CREATE DATABASE [Prueba_QPH_Galo_Baque]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Prueba_QPH_Galo_Baque', FILENAME = N'/var/opt/mssql/data/Prueba_QPH_Galo_Baque.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Prueba_QPH_Galo_Baque_log', FILENAME = N'/var/opt/mssql/data/Prueba_QPH_Galo_Baque_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Prueba_QPH_Galo_Baque].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET ARITHABORT OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET RECOVERY FULL 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET  MULTI_USER 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Prueba_QPH_Galo_Baque', N'ON'
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET QUERY_STORE = OFF
GO
USE [Prueba_QPH_Galo_Baque]
GO
/****** Object:  Table [Clientes]    Script Date: 17/4/2022 20:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](200) NULL,
	[Telefono] [varchar](15) NULL,
	[Estado] [bit] NOT NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [Cliente_IdCliente_PK] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Cuentas]    Script Date: 17/4/2022 20:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [Cuentas](
	[IdCuenta] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[NumeroCuenta] [varchar](10) NOT NULL,
	[Saldo] [decimal](8, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [Cuentas_IdCuenta_PK] PRIMARY KEY CLUSTERED 
(
	[IdCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Formularios]    Script Date: 17/4/2022 20:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Formularios](
	[IdFormulario] [int] IDENTITY(1,1) NOT NULL,
	[NombreFormulario] [varchar](50) NOT NULL,
	[Controlador] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
	[CssIcon] [varchar](50) NULL,
	[NombreVisualizar] [varchar](50) NULL,
 CONSTRAINT [PK_Formularios] PRIMARY KEY CLUSTERED 
(
	[IdFormulario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [FormulariosRol]    Script Date: 17/4/2022 20:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [FormulariosRol](
	[IdFormularioRol] [int] IDENTITY(1,1) NOT NULL,
	[IdFormulario] [int] NOT NULL,
	[IdRol] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Movimientos]    Script Date: 17/4/2022 20:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Movimientos](
	[IdMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[IdCuenta] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Tipo] [varchar](10) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
 CONSTRAINT [Movimientos_IdMovimiento_PK] PRIMARY KEY CLUSTERED 
(
	[IdMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Rol]    Script Date: 17/4/2022 20:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](20) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [UsuarioRol]    Script Date: 17/4/2022 20:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [UsuarioRol](
	[IdUsuarioRol] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdRol] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioRol] PRIMARY KEY CLUSTERED 
(
	[IdUsuarioRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Usuarios]    Script Date: 17/4/2022 20:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](100) NOT NULL,
	[Contrasena] [varchar](300) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [Clientes] ([IdCliente])
GO
ALTER TABLE [Cuentas] CHECK CONSTRAINT [FK_Cuentas_Cliente]
GO
ALTER TABLE [FormulariosRol]  WITH CHECK ADD  CONSTRAINT [FK_FormularioRol_Formularios] FOREIGN KEY([IdFormulario])
REFERENCES [Formularios] ([IdFormulario])
GO
ALTER TABLE [FormulariosRol] CHECK CONSTRAINT [FK_FormularioRol_Formularios]
GO
ALTER TABLE [FormulariosRol]  WITH CHECK ADD  CONSTRAINT [FK_FormularioRol_Rol] FOREIGN KEY([IdRol])
REFERENCES [Rol] ([IdRol])
GO
ALTER TABLE [FormulariosRol] CHECK CONSTRAINT [FK_FormularioRol_Rol]
GO
ALTER TABLE [Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Cuentas] FOREIGN KEY([IdCuenta])
REFERENCES [Cuentas] ([IdCuenta])
GO
ALTER TABLE [Movimientos] CHECK CONSTRAINT [FK_Movimientos_Cuentas]
GO
ALTER TABLE [UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Rol] FOREIGN KEY([IdRol])
REFERENCES [Rol] ([IdRol])
GO
ALTER TABLE [UsuarioRol] CHECK CONSTRAINT [FK_UsuarioRol_Rol]
GO
ALTER TABLE [UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [Usuarios] ([IdUsuario])
GO
ALTER TABLE [UsuarioRol] CHECK CONSTRAINT [FK_UsuarioRol_Usuario]
GO
/****** Object:  StoredProcedure [ps_clientes]    Script Date: 17/4/2022 20:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [ps_clientes] (
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

GO
/****** Object:  StoredProcedure [ps_cuentas]    Script Date: 17/4/2022 20:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [ps_cuentas]
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

GO
/****** Object:  StoredProcedure [ps_movimientos]    Script Date: 17/4/2022 20:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [ps_movimientos]
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

GO
/****** Object:  StoredProcedure [ps_seguridad]    Script Date: 17/4/2022 20:30:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [ps_seguridad]
	@accion [char](1),
	@nombre_usuario		[varchar](100)		= null,
	@contrasena			[varchar](300)		= null,
	@id_rol				[int]				= null
WITH EXECUTE AS CALLER
AS
IF @accion = 'L'
BEGIN	
	SELECT	u.NombreUsuario, u.IdUsuario, ur.IdRol
		FROM	[dbo].[Usuarios] u WITH(NOLOCK)
		JOIN	[dbo].[UsuarioRol] ur WITH(NOLOCK) ON ur.IdUsuario=u.IdUsuario
		WHERE  u.NombreUsuario=@nombre_usuario and u.Contrasena=@contrasena  and u.Estado=1
			
	RETURN 0
END
IF @accion = 'F'
BEGIN	
	SELECT	fr.IdRol, ISNULL(f.NombreFormulario, '')AS NombreFormulario, ISNULL(f.Controlador,'')AS Controlador, ISNULL(f.CssIcon,'') AS CssIcon, ISNULL(NombreVisualizar,'') AS NombreVisualizar
		FROM	[dbo].[FormulariosRol] fr 
		JOIN	[dbo].[Formularios] f WITH(NOLOCK) ON f.IdFormulario=fr.IdFormulario
		WHERE fr.IdRol=@id_rol and f.Estado=1
			
	RETURN 0
END
RAISERROR ('El código de la acción es incorrecto.',16,1)
GO
USE [master]
GO
ALTER DATABASE [Prueba_QPH_Galo_Baque] SET  READ_WRITE 
GO
