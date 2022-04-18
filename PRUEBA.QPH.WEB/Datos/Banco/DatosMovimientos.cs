using PRUEBA.QPH.WEB.Models.Banco;
using RestSharp;
using System.Threading.Tasks;

namespace PRUEBA.QPH.WEB.Datos.Banco {
    public class DatosMovimientos {
        private readonly string ruta;
        public DatosMovimientos(string _ruta)
        {
            ruta = _ruta;
        }
        public async Task<GrabarMovimientosResponse> Guardar(GrabarMovimientosRequest requestData)
        {
            var client = new RestClient(ruta);
            var request = new RestRequest($"/grabar", Method.Post);
            request.AddHeader("Accept", "application/json");
            var body = new {
                IdCuenta = requestData.IdCuenta,
                Fecha = requestData.Fecha,
                Tipo = requestData.Tipo,
                Valor = requestData.Valor,
            };
            request.AddJsonBody(body);
            var response = await client.ExecuteAsync<GrabarMovimientosResponse>(request);
            return response.Data;
        }      
        public async Task<PageCollection> Listar(ListarMovimientosRequest parm)
        {
            var client = new RestClient(ruta);
            var request = new RestRequest($"/listar?Fecha="+parm.Fecha.ToString("yyyy-MM-dd")+"&FechaFin="+parm.FechaFin.ToString("yyyy-MM-dd") + "&OffSet=" + parm.OffSet + "&Limit=" + parm.Limit, Method.Get);

            var restApi = await client.ExecuteAsync<PageCollection>(request);
            return restApi.Data;
        }
    }
}
