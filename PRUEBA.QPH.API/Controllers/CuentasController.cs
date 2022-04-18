using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PRUEBA.QPH.API.Common;
using PRUEBA.QPH.API.Entidades.Consultas;
using PRUEBA.QPH.API.Entidades.Operaciones;
using PRUEBA.QPH.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRUEBA.QPH.API.Controllers
{
    [Route("api/cuentas")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        #region Miembros privados del controlador

        private readonly ICuentas cuentas;
        private readonly IConfiguration configuration;
        #endregion

        #region Constructores del controlador

        public CuentasController(ICuentas _cuentas, IConfiguration config = null)
        {
            cuentas = _cuentas;
            configuration = config;
        }

        #endregion

        #region Operaciones del controlador       

        [HttpGet("listar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PageCollection<ListarCuentasResponse>>> Listar([FromQuery] ListarCuentasRequest request)
        {
            try
            {
                var response = await cuentas.Listar(request, configuration.GetConnectionString("ConecctionDbTest"));

                return Ok(response);
            }
            catch (Exception e)
            {
                return ResponseFaultListar(e);
            }
        }

        private ActionResult<PageCollection<ListarCuentasResponse>> ResponseFaultListar(Exception e)
        {
            throw new Exception(e.Message);
        }

        [HttpPost("grabar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GrabarCuentasResponse>> Grabar([FromBody] GrabarCuentasRequest request)
        {
            try
            {
                request.IsValid();
                var response = await cuentas.Grabar(request, configuration.GetConnectionString("ConecctionDbTest"));

                return Created(string.Empty, response);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }

        [HttpPut("eliminar")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<GrabarCuentasResponse> Eliminar([FromBody] EliminarCuentasRequest request)
        {
            try
            {
                request.IsValid();
                var response = cuentas.Eliminar(request, configuration.GetConnectionString("ConecctionDbTest"));

                return Accepted(response);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }

        private ActionResult<GrabarCuentasResponse> ResponseFault(Exception e)
        {
            throw new Exception(e.Message);
        }

        [HttpGet("consultar/{idCliente}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<ListarCuentasResponse>> Consultar(int idCliente)
        {
            try
            {
                var response =  cuentas.Consultar(idCliente, configuration.GetConnectionString("ConecctionDbTest"));

                return Ok(response);
            }
            catch (Exception e)
            {
                return ResponseConsultar(e);
            }
        }

        private ActionResult<List<ListarCuentasResponse>> ResponseConsultar(Exception e)
        {
            throw new NotImplementedException(e.Message);
        }
        #endregion
    }   
}
