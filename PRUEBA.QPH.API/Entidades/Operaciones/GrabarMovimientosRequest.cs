using Newtonsoft.Json;
using PRUEBA.QPH.API.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA.QPH.API.Entidades.Operaciones
{
    public class GrabarMovimientosRequest
    {
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
        public void IsValid()
        {
            if (IdCuenta <= 0)
            {
                throw new ValidationException(string.Format(MensajesOperaciones.ERROR_VAL_02, "IdCuenta"));
            }
            if (string.IsNullOrEmpty(Tipo))
            {
                throw new ValidationException(string.Format(MensajesOperaciones.ERROR_VAL_02, "Tipo"));
            }
            if (Valor <= 0)
            {
                throw new ValidationException(string.Format(MensajesOperaciones.ERROR_VAL_02, "Valor"));
            }
            if (Fecha == DateTime.MinValue)
            {
                throw new ValidationException(string.Format(MensajesOperaciones.ERROR_VAL_02, "Fecha"));
            }
        }
    }
}
