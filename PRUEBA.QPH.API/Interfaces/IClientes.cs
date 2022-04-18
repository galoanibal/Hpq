using PRUEBA.QPH.API.Entidades.Consultas;
using PRUEBA.QPH.API.Common;
using System.Threading.Tasks;
using PRUEBA.QPH.API.Entidades.Operaciones;

namespace PRUEBA.QPH.API.Interfaces
{
    public interface IClientes
    {
        PageCollection<ListarClienteResponse> Listar(ListarClienteRequest request, string connectionString);
        Task<GrabarClienteResponse> Grabar(GrabarClienteRequest request, string connectionString);
        Task<GrabarClienteResponse> Eliminar(EliminarClienteRequest request, string connectionString);
    }
}
