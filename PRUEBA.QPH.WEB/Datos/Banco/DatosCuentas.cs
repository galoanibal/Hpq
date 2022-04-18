using PRUEBA.QPH.WEB.Models.Banco;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRUEBA.QPH.WEB.Datos.Banco {
    public class DatosCuentas {
        private readonly string ruta;
        public DatosCuentas(string _ruta)
        {
            ruta = _ruta;
        }
        public async Task<GrabarCuentasResponse> Guardar(GrabarCuentasRequest requestData)
        {
            var client = new RestClient(ruta);
            var request = new RestRequest($"/grabar", Method.Post);
            request.AddHeader("Accept", "application/json");
            var body = new {
                IdCuenta = requestData.IdCuenta,
                IdCliente = requestData.IdCliente,
                NumeroCuenta = requestData.NumeroCuenta,
                Saldo = requestData.Saldo,
                Estado = requestData.Estado,
            };
            request.AddJsonBody(body);
            var response = await client.ExecuteAsync<GrabarCuentasResponse>(request);
            return response.Data;
        }
        public async Task<GrabarCuentasResponse> Eliminar(EliminarCuentasRequest requestData)
        {
            var client = new RestClient(ruta);
            var request = new RestRequest($"/eliminar", Method.Put);
            request.AddHeader("Accept", "application/json");
            var body = new {
                IdCuenta = requestData.IdCuenta,
                Estado = requestData.Estado,
            };
            request.AddJsonBody(body);
            var response = await client.ExecuteAsync<GrabarCuentasResponse>(request);
            return response.Data;
        }
        public async Task<PageCollection> Listar(ListarClienteRequest parm)
        {
            var client = new RestClient(ruta);
            var request = new RestRequest($"/listar?OffSet=" + parm.OffSet + "&Limit=" + parm.Limit, Method.Get);

            var restApi = await client.ExecuteAsync<PageCollection>(request);
            return restApi.Data;
        }
        public async Task<List<dynamic>> Consultar(int idCuenta)
        {
            var client = new RestClient(ruta);
            var request = new RestRequest("/consultar/" + idCuenta, Method.Get);          

            var restApi = await client.GetAsync<List<dynamic>>(request);
            return restApi;
        }
    }
}
