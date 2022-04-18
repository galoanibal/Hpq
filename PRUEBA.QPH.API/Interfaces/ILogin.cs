using PRUEBA.QPH.API.Entidades.Consultas;
using System.Collections.Generic;

namespace PRUEBA.QPH.API.Interfaces
{
    public interface ILogin
    {
        Login Consultar(ConsultarLoginRequest request, string getConnectionString);
        List<ListarFormulariosResponse> Listar(ListarFormulariosRequest request, string connectionString);
    }
}
