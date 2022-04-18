using Newtonsoft.Json;

namespace PRUEBA.QPH.WEB.Models.Seguridad {
    public class Formulario {
        [JsonProperty("idRol")]
        public int IdRol { get; set; }
        [JsonProperty("nombreFormulario")]
        public string NombreFormulario { get; set; }
        [JsonProperty("controlador")]
        public string Controlador { get; set; }
        [JsonProperty("cssIcon")]
        public string CssIcon { get; set; }
        [JsonProperty("nombreVisualizar")]
        public string NombreVisualizar { get; set; }
    }
}
