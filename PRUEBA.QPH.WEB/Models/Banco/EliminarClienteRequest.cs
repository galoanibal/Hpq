using Newtonsoft.Json;

namespace PRUEBA.QPH.WEB.Models.Banco {
    public class EliminarClienteRequest {
        [JsonProperty("idCliente")]
        public int IdCliente { get; set; }
        [JsonProperty("estado")]
        public bool Estado { get; set; }
    }
}
