using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRUEBA.QPH.WEB.Datos.Seguridad;
using System;

namespace PRUEBA.QPH.WEB.Controllers
{
    public class LoginController : ApplicationControllerBase {
        private readonly string ruta= "http://192.168.100.8/api/movimientos";
        private DatosLogin DatosLogin { get; set; } = null;
        public LoginController() {
            DatosLogin =new DatosLogin(ruta);
        }
        public IActionResult Index()
        {
            if (IdUsuario > 0)
            {
              return  Redirect("/Home");
            }
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public JsonResult ValidarUsuario(string nombreUsuario, string contrasena)
        {
            try
            {
                if (!string.IsNullOrEmpty(nombreUsuario) && !string.IsNullOrEmpty(contrasena))
                {
                    var respUsuario = DatosLogin.ValidarUsuario(nombreUsuario, contrasena);
                    if (respUsuario != null && respUsuario.Result.IdUsuario != 0)
                    {
                        IdRol = respUsuario.Result.IdRol;                                     
                        this.IdUsuario = respUsuario.Result.IdUsuario;
                        this.NombreUsuario = respUsuario.Result.NombreUsuario;
                        var respFormularios = DatosLogin.ListarFormularios(IdRol);
                        this.ListaFormulario = respFormularios.Result;
                        return Json(new { Mensaje = "Proceso Exitoso", ProcesoExitoso = true, respFormularios });
                    }
                    return Json(new { Mensaje = "Error: no existe el usuario " + respUsuario, ProcesoExitoso = false });
                }
                return Json(new { Mensaje = "Error: no existe el usuario", ProcesoExitoso = false });
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, ProcesoExitoso = false });
            }
        }
        [AllowAnonymous]
        public IActionResult Logout()
        {
            this.HttpContext.SignOutAsync();
            this.HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
