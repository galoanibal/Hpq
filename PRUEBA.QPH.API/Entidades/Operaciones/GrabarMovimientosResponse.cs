using Newtonsoft.Json;

namespace PRUEBA.QPH.API.Entidades.Operaciones
{
    public class GrabarMovimientosResponse
    {
        [JsonProperty("idMovimiento")]
        public int IdMovimiento { get; set; }       
        [JsonProperty("mensajeOk")]
        public string MensajeOk { get; set; }
        [JsonProperty("mensajeError")]
        public string MensajeError { get; set; }
    }
}
