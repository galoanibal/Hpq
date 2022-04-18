using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PRUEBA.QPH.API.Common;
using PRUEBA.QPH.API.Entidades.Consultas;
using PRUEBA.QPH.API.Entidades.Operaciones;
using PRUEBA.QPH.API.Interfaces;
using System;

namespace PRUEBA.QPH.API.Controllers
{
    [Route("api/movimientos")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        #region Miembros privados del controlador

        private readonly IMovimientos movimientos;
        private readonly IConfiguration configuration;
        #endregion

        #region Constructores del controlador

        public MovimientosController(IMovimientos _movimientos, IConfiguration config = null)
        {
            movimientos = _movimientos;
            configuration = config;
        }

        #endregion

        #region Operaciones del controlador       

        [HttpGet("listar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PageCollection<ListarMovimientosResponse>> Listar([FromQuery] ListarMovimientosRequest request)
        {
            try
            {
                var response =  movimientos.Listar(request, configuration.GetConnectionString("ConecctionDbTest"));

                return Ok(response);
            }
            catch (Exception e)
            {
                return ResponseFaultListar(e);
            }
        }

        private ActionResult<PageCollection<ListarMovimientosResponse>> ResponseFaultListar(Exception e)
        {
            throw new Exception(e.Message);
        }

        [HttpPost("grabar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public  ActionResult<GrabarMovimientosResponse> Grabar([FromBody] GrabarMovimientosRequest request)
        {
            try
            {
                request.IsValid();
                var response =  movimientos.Grabar(request, configuration.GetConnectionString("ConecctionDbTest"));

                return Created(string.Empty, response);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }
      
        private ActionResult<GrabarMovimientosResponse> ResponseFault(Exception e)
        {
            throw new Exception(e.Message);
        }
        #endregion
    }
}
