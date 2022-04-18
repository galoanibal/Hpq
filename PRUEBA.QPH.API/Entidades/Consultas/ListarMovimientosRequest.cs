using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA.QPH.API.Entidades.Consultas
{
    public class ListarMovimientosRequest
    {
        [JsonProperty("fecha")]
        [Required]
        public DateTime Fecha { get; set; }
        [JsonProperty("fechaFin")]
        [Required]
        public DateTime FechaFin { get; set; }
        [JsonProperty("offset")]
        [Required]
        public int OffSet { get; set; }
        [JsonProperty("limit")]
        [Required]
        public int Limit { get; set; }
    }
}
