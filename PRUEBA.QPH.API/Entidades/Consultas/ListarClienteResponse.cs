using Newtonsoft.Json;

namespace PRUEBA.QPH.API.Entidades.Consultas
{
    public class ListarClienteResponse
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
    }
}
