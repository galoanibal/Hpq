using PRUEBA.QPH.API.Common;
using PRUEBA.QPH.API.Entidades.Consultas;
using PRUEBA.QPH.API.Entidades.Operaciones;

namespace PRUEBA.QPH.API.Interfaces
{
    public interface IMovimientos
    {
        PageCollection<ListarMovimientosResponse> Listar(ListarMovimientosRequest request, string connectionString);
        GrabarMovimientosResponse Grabar(GrabarMovimientosRequest request, string connectionString);
    }
}
