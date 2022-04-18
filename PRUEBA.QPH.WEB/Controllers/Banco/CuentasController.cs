using Microsoft.AspNetCore.Mvc;
using PRUEBA.QPH.WEB.Datos.Banco;
using PRUEBA.QPH.WEB.Models.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRUEBA.QPH.WEB.Controllers.Banco {
    public class CuentasController : ApplicationControllerBase {
        private readonly string ruta = "http://192.168.100.8/api/cuentas";
        private DatosCuentas DatosCuentas { get; set; } = null;
        public CuentasController()
        {
            DatosCuentas = new DatosCuentas(ruta);
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
        public JsonResult Guardar(GrabarCuentasRequest request)
        {
            try
            {
                if (request != null && !string.IsNullOrEmpty(request.NumeroCuenta) && request.Saldo>0)
                {
                    request.IdCliente = IdUsuario;
                    var resp = DatosCuentas.Guardar(request);
                    if (resp.Result != null && resp.Result.IdCuenta != 0)
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
        public JsonResult Eliminar(EliminarCuentasRequest request)
        {
            try
            {
                if (request != null && request.IdCuenta != 0 && !request.Estado)
                {
                    var resp = DatosCuentas.Eliminar(request);
                    if (resp.Result != null && resp.Result.IdCuenta != 0)
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
                if (request != null && request.OffSet != 0 && request.Limit != 0)
                {
                    var resp = DatosCuentas.Listar(request);
                    if (resp != null && resp.Result != null && resp.Result.Data.Any())
                    {
                        return Json(new { Mensaje = "Proceso Exitoso", ProcesoExitoso = true, resp = resp.Result.Data });
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
        [HttpGet]
        public JsonResult ConsultarCuenta()
        {
            try
            {
                if (IdUsuario != 0)
                {
                    var resp = DatosCuentas.Consultar(IdUsuario);
                    if (resp != null && resp.Result != null && resp.Result != null && resp.Result.Any())
                    {
                        return Json(new { Mensaje = "Proceso Exitoso", ProcesoExitoso = true, resp = resp.Result });
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
