using Newtonsoft.Json;

namespace PRUEBA.QPH.WEB.Models.Banco {
    public class GrabarMovimientosResponse {
        [JsonProperty("idMovimiento")]
        public int IdMovimiento { get; set; }
        [JsonProperty("mensajeOk")]
        public string MensajeOk { get; set; }
        [JsonProperty("mensajeError")]
        public string MensajeError { get; set; }
    }
}
