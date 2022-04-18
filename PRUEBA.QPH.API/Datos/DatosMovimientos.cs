using PRUEBA.QPH.API.Common;
using PRUEBA.QPH.API.Entidades.Consultas;
using PRUEBA.QPH.API.Entidades.Operaciones;
using PRUEBA.QPH.API.Interfaces;
using PRUEBA.QPH.API.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PRUEBA.QPH.API.Datos
{
    public class DatosMovimientos : IMovimientos
    {
        #region Constructores de la clase

        public DatosMovimientos()
        {

        }
        #endregion

        #region Implementación de la interface
        GrabarMovimientosResponse IMovimientos.Grabar(GrabarMovimientosRequest request, string connectionString)
        {
            return GrabarAsync(request, connectionString);
        }

        PageCollection<ListarMovimientosResponse> IMovimientos.Listar(ListarMovimientosRequest request, string connectionString)
        {
            return ListarAsync(request, connectionString);
        }
        #endregion

        #region Métodos de consulta de la clase       
        private PageCollection<ListarMovimientosResponse> ListarAsync(ListarMovimientosRequest request, string getConnectionString)
        {
            List<ListarMovimientosResponse> list = new List<ListarMovimientosResponse>();
            using (SqlConnection conn = new SqlConnection(getConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ps_movimientos";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@accion", SqlDbType.Char).Value = "L";
                cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = request.Fecha;
                cmd.Parameters.Add("@fecha_fin", SqlDbType.DateTime).Value = request.FechaFin;
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
                    list = ConvertToList.ConvertDataTable<ListarMovimientosResponse>(ds.Tables[1]);
                }

                return new PageCollection<ListarMovimientosResponse>(list, totalRegistros, request.Limit);
            }
        }
        #endregion

        #region Métodos de operaciones de la clase
        private GrabarMovimientosResponse GrabarAsync(GrabarMovimientosRequest request, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ps_movimientos";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@accion", SqlDbType.Char).Value = "I";
                cmd.Parameters.Add("@id_cuenta", SqlDbType.Int).Value = request.IdCuenta;
                cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = request.Fecha;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = request.Tipo;
                cmd.Parameters.Add("@valor", SqlDbType.Decimal).Value = request.Valor;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                adp.Fill(ds);
                int idMovimiento = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    idMovimiento = Convert.ToInt32(ds.Tables[0].Rows[0]["IdMovimiento"]);
                    return new GrabarMovimientosResponse()
                    {
                        IdMovimiento = idMovimiento,
                        MensajeOk = string.Format(MensajesOperaciones.OK_VAL_100, MensajesOperaciones.CODE_OK_VAL_100)
                    };
                }
                else
                {
                    return new GrabarMovimientosResponse()
                    {
                        IdMovimiento = idMovimiento,
                        MensajeOk = string.Format(MensajesOperaciones.ERROR_VAL_01, MensajesOperaciones.CODE_ERROR_VAL_01)
                    };
                }
            }
        }
        #endregion
    }
}
