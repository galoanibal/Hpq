using PRUEBA.QPH.API.Common;
using PRUEBA.QPH.API.Entidades.Consultas;
using PRUEBA.QPH.API.Entidades.Operaciones;
using PRUEBA.QPH.API.Interfaces;
using PRUEBA.QPH.API.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace PRUEBA.QPH.API.Datos
{
    public class DatosClientes : IClientes
    {
        #region Constructores de la clase

        public DatosClientes()
        {

        }
        #endregion

        #region Implementación de la interface
        [ExcludeFromCodeCoverage]
        async Task<GrabarClienteResponse> IClientes.Grabar(GrabarClienteRequest request, string connectionString)
        {
            return await GrabarAsync(request, connectionString);
        }
        [ExcludeFromCodeCoverage]
        async Task<GrabarClienteResponse> IClientes.Eliminar(EliminarClienteRequest request, string connectionString)
        {
            return await EliminarAsync(request, connectionString);
        }
        [ExcludeFromCodeCoverage]
         PageCollection<ListarClienteResponse> IClientes.Listar(ListarClienteRequest request, string connectionString)
        {
            return  ListarAsync(request, connectionString);
        }
        #endregion

        #region Métodos de consulta de la clase      
        [ExcludeFromCodeCoverage]
        private PageCollection<ListarClienteResponse> ListarAsync(ListarClienteRequest request, string getConnectionString)
        {
            List<ListarClienteResponse> list = new List<ListarClienteResponse>();
            using (SqlConnection conn = new SqlConnection(getConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ps_clientes";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@accion", SqlDbType.Char).Value = "L";
                cmd.Parameters.Add("@offset", SqlDbType.Int).Value = request.OffSet;
                cmd.Parameters.Add("@limit", SqlDbType.Int).Value = request.Limit;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                int totalRegistros = 0;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    totalRegistros = Convert.ToInt32(ds.Tables[0].Rows[0]["total_registros"]);
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    list = ConvertToList.ConvertDataTable<ListarClienteResponse>(ds.Tables[1]);
                }

                return new PageCollection<ListarClienteResponse>(list, totalRegistros, request.Limit);
            }
        }

        #endregion

        #region Métodos de operaciones de la clase
        [ExcludeFromCodeCoverage]
        private async Task<GrabarClienteResponse> GrabarAsync(GrabarClienteRequest request, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ps_clientes";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@accion", SqlDbType.Char).Value = request.IdCliente > 0 ? "M" : "I";
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = request.IdCliente;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = request.Nombre;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = request.Direccion;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = request.Telefono;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = request.Estado;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                adp.Fill(ds);
                int idCliente = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    idCliente = Convert.ToInt32(ds.Tables[0].Rows[0]["IdCliente"]);
                    return new GrabarClienteResponse()
                    {
                        IdCliente = idCliente,
                        MensajeOk = string.Format(MensajesOperaciones.OK_VAL_100, MensajesOperaciones.CODE_OK_VAL_100)
                    };
                }
                else
                {
                    return new GrabarClienteResponse()
                    {
                        IdCliente = idCliente,
                        MensajeOk = string.Format(MensajesOperaciones.ERROR_VAL_01, MensajesOperaciones.CODE_ERROR_VAL_01)
                    };
                }
            }
        }
        [ExcludeFromCodeCoverage]
        private async Task<GrabarClienteResponse> EliminarAsync(EliminarClienteRequest request, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ps_clientes";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@accion", SqlDbType.Char).Value = "E";
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = request.IdCliente;
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = request.Estado;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                adp.Fill(ds);
                int idCliente = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    idCliente = Convert.ToInt32(ds.Tables[0].Rows[0]["IdCliente"]);
                    return new GrabarClienteResponse()
                    {
                        IdCliente = idCliente,
                        MensajeOk = string.Format(MensajesOperaciones.OK_VAL_100, MensajesOperaciones.CODE_OK_VAL_100)
                    };
                }
                else
                {
                    return new GrabarClienteResponse()
                    {
                        IdCliente = idCliente,
                        MensajeOk = string.Format(MensajesOperaciones.ERROR_VAL_01, MensajesOperaciones.CODE_ERROR_VAL_01)
                    };
                }
            }
        }
        #endregion
    }
}
