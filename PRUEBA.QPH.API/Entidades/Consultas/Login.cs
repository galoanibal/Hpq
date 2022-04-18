using Newtonsoft.Json;

namespace PRUEBA.QPH.API.Entidades.Consultas
{
    public class Login
    {
        [JsonProperty("nombreUsuario")]
        public string NombreUsuario { get; set; }
        [JsonProperty("idUsuario")]
        public int IdUsuario { get; set; }
        [JsonProperty("idRol")]
        public int IdRol { get; set; }       
    }
}
