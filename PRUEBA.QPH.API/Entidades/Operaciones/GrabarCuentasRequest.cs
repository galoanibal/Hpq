using Newtonsoft.Json;
using PRUEBA.QPH.API.Utils;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA.QPH.API.Entidades.Operaciones
{
    public class GrabarCuentasRequest
    {
        [JsonProperty("idCuenta")]
        public int IdCuenta { get; set; }
        [JsonProperty("idCliente")]
        public int IdCliente { get; set; }
        [JsonProperty("numeroCuenta")]
        public string NumeroCuenta { get; set; }
        [JsonProperty("saldo")]
        public decimal Saldo { get; set; }
        [JsonProperty("estado")]
        public bool Estado { get; set; }
        public void IsValid()
        {
            if (IdCliente <= 0)
            {
                throw new ValidationException(string.Format(MensajesOperaciones.ERROR_VAL_02, "IdCliente"));
            }
            if (string.IsNullOrEmpty(NumeroCuenta))
            {
                throw new ValidationException(string.Format(MensajesOperaciones.ERROR_VAL_02, "NumeroCuenta"));
            }            
            if (Saldo <= 0)
            {
                throw new ValidationException(string.Format(MensajesOperaciones.ERROR_VAL_02, "SaldoInicial"));
            }

        }
    }
}
