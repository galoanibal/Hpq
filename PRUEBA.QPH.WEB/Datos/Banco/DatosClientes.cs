using PRUEBA.QPH.WEB.Models.Banco;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRUEBA.QPH.WEB.Datos.Banco {
    public class DatosClientes {
        private readonly string ruta;
        public DatosClientes(string _ruta)
        {
            ruta = _ruta;
        }
        public async Task<GrabarClienteResponse> Guardar(GrabarClienteRequest requestData)
        {
            var client = new RestClient(ruta);
            var request = new RestRequest($"/grabar", Method.Post);
            request.AddHeader("Accept", "application/json");
            var body = new {
                IdCliente = requestData.IdCliente,
                Nombre = requestData.Nombre,
                Direccion = requestData.Direccion,
                Telefono = requestData.Telefono,
                Estado = requestData.Estado,
            };
            request.AddJsonBody(body);
            var response =await  client.ExecuteAsync<GrabarClienteResponse>(request);
            return response.Data;
        }
        public async Task<GrabarClienteResponse> Eliminar(EliminarClienteRequest requestData)
        {
            var client = new RestClient(ruta);
            var request = new RestRequest($"/eliminar", Method.Put);
            request.AddHeader("Accept", "application/json");
            var body = new {
                IdCliente = requestData.IdCliente,              
                Estado = requestData.Estado,
            };
            request.AddJsonBody(body);
            var response = await client.ExecuteAsync<GrabarClienteResponse>(request);
            return response.Data;
        }
        public async Task<PageCollection> Listar(ListarClienteRequest parm)
        {
            var client = new RestClient(ruta);
            var request = new RestRequest($"/listar?OffSet=" + parm.OffSet + "&Limit=" + parm.Limit, Method.Get);

            var restApi = await client.ExecuteAsync<PageCollection>(request);
            return restApi.Data;
        }
    }
}
