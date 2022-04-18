using Newtonsoft.Json;

namespace PRUEBA.QPH.WEB.Models.Banco {
    public class EliminarCuentasRequest {
        [JsonProperty("idCuenta")]
        public int IdCuenta { get; set; }
        [JsonProperty("estado")]
        public bool Estado { get; set; }
    }
}
