using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA.QPH.API.Entidades.Consultas
{
    public class ConsultarLoginRequest
    {
        [JsonProperty("nombreUsuario")]
        [Required]
        public string NombreUsuario { get; set; }
        [JsonProperty("contrasena")]
        [Required]
        public string Contrasena { get; set; }
    }

    public class ListarFormulariosRequest {
        [JsonProperty("idRol")]
        [Required]
        public int IdRol { get; set; }
    }
}
