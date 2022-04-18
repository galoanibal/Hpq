using PRUEBA.QPH.API.Common;
using PRUEBA.QPH.API.Entidades.Consultas;
using PRUEBA.QPH.API.Entidades.Operaciones;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRUEBA.QPH.API.Interfaces
{
    public interface ICuentas
    {
        Task<PageCollection<ListarCuentasResponse>> Listar(ListarCuentasRequest request, string connectionString);
        Task<GrabarCuentasResponse> Grabar(GrabarCuentasRequest request, string connectionString);
        GrabarCuentasResponse Eliminar(EliminarCuentasRequest request, string connectionString);
        List<ListarCuentasResponse> Consultar(int idCliente, string getConnectionString);
    }
}
