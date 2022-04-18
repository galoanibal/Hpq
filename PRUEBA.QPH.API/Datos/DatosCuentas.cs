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
    public class DatosCuentas : ICuentas
    {
        #region Constructores de la clase

        public DatosCuentas()
        {

        }
        #endregion

        #region Implementación de la interface
        [ExcludeFromCodeCoverage]
        List<ListarCuentasResponse> ICuentas.Consultar(int idCliente , string getConnectionString)
        {
            return Consultar(idCliente, getConnectionString);
        }
        [ExcludeFromCodeCoverage]
        async Task<GrabarCuentasResponse> ICuentas.Grabar(GrabarCuentasRequest request, string connectionString)
        {
            return await GrabarAsync(request, connectionString);
        }
        [ExcludeFromCodeCoverage]
        GrabarCuentasResponse ICuentas.Eliminar(EliminarCuentasRequest request, string connectionString)
        {
            return  EliminarAsync(request, connectionString);
        }
        [ExcludeFromCodeCoverage]
        async Task<PageCollection<ListarCuentasResponse>> ICuentas.Listar(ListarCuentasRequest request, string connectionString)
        {
            return await ListarAsync(request, connectionString);
        }
        #endregion

        #region Métodos de consulta de la clase       
        [ExcludeFromCodeCoverage]
        private async Task<PageCollection<ListarCuentasResponse>> ListarAsync(ListarCuentasRequest request, string getConnectionString)
        {
            List<ListarCuentasResponse> list = new List<ListarCuentasResponse>();
            using (SqlConnection conn = new SqlConnection(getConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ps_cuentas";
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
                    list = ConvertToList.ConvertDataTable<ListarCuentasResponse>(ds.Tables[1]);
                }

                return new PageCollection<ListarCuentasResponse>(list, totalRegistros, request.Limit);
            }
        }
        [ExcludeFromCodeCoverage]
        private List<ListarCuentasResponse> Consultar(int idCliente, string getConnectionString)
        {
            List<ListarCuentasResponse> listCuentas = new List<ListarCuentasResponse>();
            using (SqlConnection conn = new SqlConnection(getConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ps_cuentas";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@accion", SqlDbType.Char).Value = "C";
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = idCliente;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                adp.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    listCuentas = ConvertToList.ConvertDataTable<ListarCuentasResponse>(ds.Tables[0]);                   
                }
                return listCuentas;
            }
        }
        #endregion

        #region Métodos de operaciones de la clase
        [ExcludeFromCodeCoverage]
        private async Task<GrabarCuentasResponse> GrabarAsync(GrabarCuentasRequest request, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ps_cuentas";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@accion", SqlDbType.Char).Value = request.IdCuenta > 0 ? "M" : "I";
                cmd.Parameters.Add("@id_cuenta", SqlDbType.Int).Value = request.IdCuenta;
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = request.IdCliente;
                cmd.Parameters.Add("@numero_cuenta", SqlDbType.VarChar).Value = request.NumeroCuenta;               
                cmd.Parameters.Add("@saldo", SqlDbType.Decimal).Value = request.Saldo;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = request.Estado;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                adp.Fill(ds);
                int idCuenta = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    idCuenta = Convert.ToInt32(ds.Tables[0].Rows[0]["IdCuenta"]);
                    return new GrabarCuentasResponse()
                    {
                        IdCuenta = idCuenta,
                        MensajeOk = string.Format(MensajesOperaciones.OK_VAL_100, MensajesOperaciones.CODE_OK_VAL_100)
                    };
                }
                else
                {
                    return new GrabarCuentasResponse()
                    {
                        IdCuenta = idCuenta,
                        MensajeOk = string.Format(MensajesOperaciones.ERROR_VAL_01, MensajesOperaciones.CODE_ERROR_VAL_01)
                    };
                }
            }
        }
        [ExcludeFromCodeCoverage]
        private GrabarCuentasResponse EliminarAsync(EliminarCuentasRequest request, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ps_cuentas";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@accion", SqlDbType.Char).Value = "E";
                cmd.Parameters.Add("@id_cuenta", SqlDbType.Int).Value = request.IdCuenta;
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = request.Estado;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                adp.Fill(ds);
                int idCuenta = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    idCuenta = Convert.ToInt32(ds.Tables[0].Rows[0]["IdCuenta"]);
                    return new GrabarCuentasResponse()
                    {
                        IdCuenta = idCuenta,
                        MensajeOk = string.Format(MensajesOperaciones.OK_VAL_100, MensajesOperaciones.CODE_OK_VAL_100)
                    };
                }
                else
                {
                    return new GrabarCuentasResponse()
                    {
                        IdCuenta = idCuenta,
                        MensajeOk = string.Format(MensajesOperaciones.ERROR_VAL_01, MensajesOperaciones.CODE_ERROR_VAL_01)
                    };
                }
            }
        }
        #endregion
    }
}
