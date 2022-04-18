using Newtonsoft.Json;

namespace PRUEBA.QPH.API.Entidades.Consultas
{
    public class ListarCuentasResponse
    {
        [JsonProperty("idCuenta")]
        public int IdCuenta { get; set; }
        [JsonProperty("idCliente")]
        public int IdCliente { get; set; }
        [JsonProperty("numeroCuenta")]
        public string NumeroCuenta { get; set; }       
        [JsonProperty("saldo")]
        public decimal Saldo { get; set; }
        [JsonProperty("estado")]
        public bool Estado { get; set; }
    }
}
