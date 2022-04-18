using Microsoft.AspNetCore.Mvc;
using PRUEBA.QPH.WEB.Datos.Banco;
using PRUEBA.QPH.WEB.Models.Banco;
using System;
using System.Linq;

namespace PRUEBA.QPH.WEB.Controllers.Banco {   
    public class ClientesFrontController :ApplicationControllerBase {
        private readonly string ruta = "http://192.168.100.8/api/clientes";
        private DatosClientes DatosClientes { get; set; } = null;
        public ClientesFrontController()
        {
            DatosClientes = new DatosClientes(ruta);
        }
        public IActionResult Index()
        {
            if (IdUsuario == 0)
            {
                return Redirect("/Login");
            }
            return View();
        }
        [HttpPost]
        public JsonResult Guardar(GrabarClienteRequest request) {
            try
            {
                if (request!=null && !string.IsNullOrEmpty(request.Nombre) )
                {
                    var resp = DatosClientes.Guardar(request);
                    if (resp.Result != null && resp.Result.IdCliente != 0)
                    {                       
                        return Json(new { Mensaje = "Proceso Exitoso", ProcesoExitoso = true, resp });
                    }
                    return Json(new { Mensaje = "Error: no se pudo grabar el Cliente" + resp, ProcesoExitoso = false });
                }
                return Json(new { Mensaje = "Error: error al enviar datos REQUEST", ProcesoExitoso = false });
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, ProcesoExitoso = false });
            }
        }
        [HttpPost]
        public JsonResult Eliminar(EliminarClienteRequest request)
        {
            try
            {
                if (request != null && request.IdCliente!=0 && !request.Estado)
                {
                    var resp = DatosClientes.Eliminar(request);
                    if (resp.Result != null && resp.Result.IdCliente != 0)
                    {
                        return Json(new { Mensaje = "Proceso Exitoso", ProcesoExitoso = true, resp });
                    }
                    return Json(new { Mensaje = "Error: no se pudo eliminar el Cliente" + resp, ProcesoExitoso = false });
                }
                return Json(new { Mensaje = "Error: error al enviar datos REQUEST", ProcesoExitoso = false });
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, ProcesoExitoso = false });
            }
        }
        [HttpGet]
        public JsonResult Listar(ListarClienteRequest request)
        {
            try
            {
                if (request != null && request.OffSet != 0 && request.Limit!=0)
                {
                    var resp = DatosClientes.Listar(request);
                    if (resp != null && resp.Result.Data.Any())
                    {
                        return Json(new { Mensaje = "Proceso Exitoso", ProcesoExitoso = true, resp= resp.Result.Data });
                    }
                    return Json(new { Mensaje = "Error: no se obtuvo datos en la consulta" + resp, ProcesoExitoso = false });
                }
                return Json(new { Mensaje = "Error: error al enviar datos REQUEST", ProcesoExitoso = false });
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, ProcesoExitoso = false });
            }
        }
    }
}
