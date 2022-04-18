using Newtonsoft.Json;

namespace PRUEBA.QPH.WEB.Models.Banco {
    public class ListarClienteRequest {
        [JsonProperty("offset")]
        public int OffSet { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
