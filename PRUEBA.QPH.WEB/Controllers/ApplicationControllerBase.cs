using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PRUEBA.QPH.WEB.Models.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PRUEBA.QPH.WEB.Controllers {
    public abstract class ApplicationControllerBase : Controller {
          #region Propiedades
        protected int IdRol {
            get => HttpContext.Session.GetIdRol();
            set => HttpContext.Session.SetIdRol(value);
        }
        protected string Controlador {
            get {
                return HttpContext.Session.GetControlador();
            }
            set {
                HttpContext.Session.SetControlador(value);
            }
        }
         
        protected int IdUsuario {
            get => HttpContext.Session.GetIdUsuario();
            set => HttpContext.Session.SetIdUsuario(value);
        }

        protected string NombreUsuario {
            get {
                return HttpContext.Session.GetNombreUsuario();
            }
            set {
                HttpContext.Session.SetNombreUsuario(value);
            }
        }
        protected string NombreFormulario {
            get {
                return HttpContext.Session.GetNombreFormulario();
            }
            set {
                HttpContext.Session.SetNombreFormulario(value);
            }
        }
        protected List<Formulario> ListaFormulario {
            get {
                return HttpContext.Session.GetListaFormularios();
            }
            set {
                HttpContext.Session.SetListaFormularios(value);
            }
        }
        #endregion       
    }
}
