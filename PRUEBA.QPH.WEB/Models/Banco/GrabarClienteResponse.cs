using Newtonsoft.Json;

namespace PRUEBA.QPH.WEB.Models.Banco {
    public class GrabarClienteResponse {
        [JsonProperty("idCliente")]
        public int IdCliente { get; set; }
        [JsonProperty("mensajeOk")]
        public string MensajeOk { get; set; }
        [JsonProperty("mensajeError")]
        public string MensajeError { get; set; }
    }
}
