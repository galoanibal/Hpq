using Newtonsoft.Json;
using System;

namespace PRUEBA.QPH.API.Entidades.Consultas
{
    public class ListarMovimientosResponse
    {
        [JsonProperty("idMovimiento")]
        public int IdMovimiento { get; set; }
        [JsonProperty("idCuenta")]
        public int IdCuenta { get; set; }
        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }
        [JsonProperty("tipo")]
        public string Tipo { get; set; }
        [JsonProperty("valor")]
        public decimal Valor { get; set; }
    }
}
