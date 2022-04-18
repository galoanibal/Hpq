using Newtonsoft.Json;
using System;

namespace PRUEBA.QPH.WEB.Models.Banco {
    public class GrabarMovimientosRequest {
        [JsonProperty("idCuenta")]
        public int IdCuenta { get; set; }
        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }
        [JsonProperty("fechaFin")]
        public DateTime FechaFin { get; set; }
        [JsonProperty("tipo")]
        public string Tipo { get; set; }
        [JsonProperty("valor")]
        public decimal Valor { get; set; }
    }
}
