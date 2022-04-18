using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace PRUEBA.QPH.WEB.Models.Seguridad {
    public static class SessionManager { 
        #region Constantes
        private const string m_IdUsuario = "idUsuario";
        private const string m_NombreUsuario = "nombreUsuario";
        private const string m_IdRol = "idRol";
        private const string m_Controlador = "controlador";
        private const string m_NombreFormulario = "nombreFormulario";
        private const string m_ListFormularios = "listFormularios";

              #endregion

        #region Métodos de manejo de la información en la sesión
        public static int GetIdRol(this ISession session)
        {
            return session.GetInt32(m_IdRol) ?? 0;
        }
        internal static void SetIdRol(this ISession session, int idRol)
        {
            session.SetInt32(m_IdRol, idRol);
        }      
      
        public static int GetIdUsuario(this ISession session)
        {
            return session.GetInt32(m_IdUsuario) ?? 0;
        }
        internal static void SetIdUsuario(this ISession session, int idUsuario)
        {
            session.SetInt32(m_IdUsuario, idUsuario);
        }

        public static string GetNombreUsuario(this ISession session)
        {
            return session.GetString(m_NombreUsuario);
        }
        internal static void SetNombreUsuario(this ISession session, string nombreUsuario)
        {
            session.SetString(m_NombreUsuario, nombreUsuario);
        }
        public static string GetControlador(this ISession session)
        {
            return session.GetString(m_Controlador);
        }
        internal static void SetControlador(this ISession session, string controlador)
        {
            session.SetString(m_Controlador, controlador);
        }
        public static string GetNombreFormulario(this ISession session)
        {
            return session.GetString(m_NombreFormulario);
        }
        internal static void SetNombreFormulario(this ISession session, string nombreFormulario)
        {
            session.SetString(m_NombreFormulario, nombreFormulario);
        }
        public static List<Formulario> GetListaFormularios(this ISession session)
        {
            var json = session.GetString(m_ListFormularios);

            return (json != null)
                ? JsonConvert.DeserializeObject<List<Formulario>>(json)
                : null;
        }
        internal static void SetListaFormularios(this ISession session, List<Formulario> listFormularios)
        {
            var json = (listFormularios != null && listFormularios.Any())
                ? JsonConvert.SerializeObject(listFormularios)
                : null;

            session.SetString(m_ListFormularios, json);
        }
        #endregion
    }
}
