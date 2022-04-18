using Newtonsoft.Json;
using System;

namespace PRUEBA.QPH.WEB.Models.Banco {
    public class ListarMovimientosRequest {
        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }
        [JsonProperty("fechaFin")]
        public DateTime FechaFin { get; set; }
        [JsonProperty("offset")]
        public int OffSet { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
