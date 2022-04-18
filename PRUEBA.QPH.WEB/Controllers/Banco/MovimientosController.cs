using Microsoft.AspNetCore.Mvc;
using PRUEBA.QPH.WEB.Datos.Banco;
using PRUEBA.QPH.WEB.Models.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRUEBA.QPH.WEB.Controllers.Banco {
    public class MovimientosController : ApplicationControllerBase {
        private readonly string ruta = "http://192.168.100.8/api/movimientos";
        private DatosMovimientos DatosMovimientos { get; set; } = null;
        public MovimientosController()
        {
            DatosMovimientos = new DatosMovimientos(ruta);
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
        public JsonResult Guardar(GrabarMovimientosRequest request)
        {
            try
            {
                if (request != null && !string.IsNullOrEmpty(request.Tipo) && request.Valor > 0)
                {
                    var resp = DatosMovimientos.Guardar(request);
                    if (resp.Result != null && resp.Result!=null && resp.Result.IdMovimiento != 0)
                    {
                        return Json(new { Mensaje = "Proceso Exitoso", ProcesoExitoso = true, resp });
                    }
                    return Json(new { Mensaje = "Error: no se pudo grabar el Movimiento" + resp, ProcesoExitoso = false });
                }
                return Json(new { Mensaje = "Error: error al enviar datos REQUEST", ProcesoExitoso = false });
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, ProcesoExitoso = false });
            }
        }
        [HttpGet]
        public JsonResult Listar(ListarMovimientosRequest request)
        {
            try
            {
                if (request != null && request.OffSet != 0 && request.Limit != 0)
                {
                    var resp = DatosMovimientos.Listar(request);
                    if (resp != null && resp.Result!=null && resp.Result.Data!=null && resp.Result.Data.Any())
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
    }
}
