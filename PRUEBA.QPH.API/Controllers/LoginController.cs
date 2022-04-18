using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PRUEBA.QPH.API.Entidades.Consultas;
using PRUEBA.QPH.API.Interfaces;
using System;
using System.Collections.Generic;

namespace PRUEBA.QPH.API.Controllers
{
    [Route("api/movimientos")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Miembros privados del controlador

        private readonly ILogin login;
        private readonly IConfiguration configuration;
        #endregion

        #region Constructores del controlador

        public LoginController(ILogin _login, IConfiguration config = null)
        {
            login = _login;
            configuration = config;
        }

        #endregion

        #region Operaciones del controlador       
        [HttpGet("consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Login> Consultar([FromQuery] ConsultarLoginRequest request )
        {
            try
            {
                var response =  login.Consultar(request, configuration.GetConnectionString("ConecctionDbTest"));

                return Ok(response);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }

        private ActionResult<Login> ResponseFault(Exception e)
        {
            throw new NotImplementedException(e.Message);
        }

        [HttpGet("listar/{idRol}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<ListarFormulariosResponse>> Listar(int idRol)
        {
            try
            {
                ListarFormulariosRequest request = new ListarFormulariosRequest();
                request.IdRol = idRol;
                var response = login.Listar(request, configuration.GetConnectionString("ConecctionDbTest"));

                return Ok(response);
            }
            catch (Exception e)
            {
                return ResponseFaultListar(e);
            }
        }

        private ActionResult<List<ListarFormulariosResponse>> ResponseFaultListar(Exception e)
        {
            throw new Exception(e.Message);
        }
        #endregion
    }
}
