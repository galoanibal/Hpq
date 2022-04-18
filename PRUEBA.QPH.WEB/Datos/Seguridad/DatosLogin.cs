using PRUEBA.QPH.WEB.Models.Seguridad;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRUEBA.QPH.WEB.Datos.Seguridad
{
    public class DatosLogin
    {
        private readonly string ruta;
        public DatosLogin(string _ruta) {
            ruta = _ruta;
        }
        public async Task<Login> ValidarUsuario(string nombreUsuario, string contrasena)
        {
            var client = new RestClient(ruta);
            var request = new RestRequest($"/consultar?NombreUsuario=" + nombreUsuario + "&Contrasena=" + contrasena, Method.Get);
            var restApi = await client.ExecuteAsync<Login>(request);
            return restApi.Data;
        }
        public async Task<List<Formulario>> ListarFormularios(int idRol)
        {
            var client = new RestClient(ruta);
            var request = new RestRequest("/listar/" + idRol, Method.Get);
            //var request = new RestRequest($"/listar", Method.Get);
            //request.AddParameter("IdRol", idRol);

            var restApi = await client.GetAsync<List<Formulario>>(request);
            return restApi;
        }
    }
}
