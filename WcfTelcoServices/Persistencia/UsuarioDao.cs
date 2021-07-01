using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfTelcoServices.Dominio;

namespace WcfTelcoServices.Persistencia
{
    public class UsuarioDao
    {
        private string conecsql = ConfigurationManager.AppSettings["connect_sql"];


        public  bool ValidarConexion(string Usuario, string Password)
        {
            bool conexionExitosa = false;

            try
            {
 
            }
            catch (Exception ex)
            {

                conexionExitosa = false;
            }



            return conexionExitosa;
        }
        public Usuario ObtenerUsuario(string codigoalumno)
        {
            Usuario _alumno = null;
            using (SqlConnection connection = new SqlConnection(conecsql))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usp_obtenerUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codigoalumno", codigoalumno);

                SqlDataReader sqlData = command.ExecuteReader();

                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        _alumno = new Usuario()
                        {
                            CodigoUsuario = sqlData["CodigoUsuario"].ToString(),
                            NombreUsuario = sqlData["NombreUsuario"].ToString(),
                            ContrasenaUsuario = sqlData["ContrasenaUsuario"].ToString(),
                        };
                    }
                }

            }
            return _alumno;
        }

    }
}