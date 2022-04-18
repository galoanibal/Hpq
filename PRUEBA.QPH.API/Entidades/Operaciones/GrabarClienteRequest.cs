using Newtonsoft.Json;
using PRUEBA.QPH.API.Utils;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA.QPH.API.Entidades.Operaciones
{
    public class GrabarClienteRequest
    {
        [JsonProperty("idCliente")]
        public int IdCliente { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("direccion")]
        public string Direccion { get; set; }
        [JsonProperty("telefono")]
        public string Telefono { get; set; }
        [JsonProperty("estado")]
        public bool Estado { get; set; }
        public void IsValid()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new ValidationException(string.Format(MensajesOperaciones.ERROR_VAL_02, "Nombre"));
            }           
        }
    }
}
