USE [Prueba_QPH_Galo_Baque]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'ps_seguridad')
	DROP PROC dbo.ps_seguridad
GO 

CREATE PROCEDURE [dbo].[ps_seguridad]
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