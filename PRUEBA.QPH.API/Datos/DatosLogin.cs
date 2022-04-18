using PRUEBA.QPH.API.Entidades.Consultas;
using PRUEBA.QPH.API.Interfaces;
using PRUEBA.QPH.API.Utils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PRUEBA.QPH.API.Datos
{
    public class DatosLogin:ILogin
    {
        #region Constructores de la clase
        public DatosLogin()
        {

        }
        #endregion

        #region Implementación de la interface
        [ExcludeFromCodeCoverage]
       Login ILogin.Consultar(ConsultarLoginRequest request, string getConnectionString)
        {
            return Consultar(request, getConnectionString);
        }
        List<ListarFormulariosResponse> ILogin.Listar(ListarFormulariosRequest request, string connectionString)
        {
            return ListarAsync(request, connectionString);
        }
        #endregion

        #region Métodos de consulta de la clase      
        [ExcludeFromCodeCoverage]
        private Login Consultar(ConsultarLoginRequest request, string getConnectionString)
        {
            Login obj = new Login();
            using (SqlConnection conn = new SqlConnection(getConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ps_seguridad";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@accion", SqlDbType.Char).Value = "L";
                cmd.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = request.NombreUsuario;
                cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = request.Contrasena;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                adp.Fill(ds);
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var list = ConvertToList.ConvertDataTable<Login>(ds.Tables[0]);
                    obj = list!=null && list.Any() ? list.FirstOrDefault(): obj;
                }
                return obj;
            }
        }
        [ExcludeFromCodeCoverage]
        private List<ListarFormulariosResponse> ListarAsync(ListarFormulariosRequest request, string getConnectionString)
        {
            List<ListarFormulariosResponse> list = new List<ListarFormulariosResponse>();
            using (SqlConnection conn = new SqlConnection(getConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ps_seguridad";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@accion", SqlDbType.Char).Value = "F";
                cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = request.IdRol;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();               
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                adp.Fill(ds);
               
                if (ds.Tables[0].Rows.Count > 0)
                {
                    list = ConvertToList.ConvertDataTable<ListarFormulariosResponse>(ds.Tables[0]);
                }
                return list;
            }
        }
        #endregion
    }
}
