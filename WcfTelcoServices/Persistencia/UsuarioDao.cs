using System;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WcfTelcoServices.Dominio;

namespace WcfTelcoServices.Persistencia
{
    public class UsuarioDao
    {
        private string conecsql = ConfigurationManager.AppSettings["connect_sql"];


        public bool ValidarConexion(Usuario usuario)
        {
            bool conexionExitosa = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(conecsql))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("usp_ValidarUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigoUsuario", usuario.CodigoUsuario);
                    cmd.Parameters.AddWithValue("@contrasnaUsuario", usuario.ContrasenaUsuario);
                    cmd.Parameters.Add("@ExisteUsuario", SqlDbType.Char, 500);
                    cmd.Parameters["@ExisteUsuario"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    conexionExitosa = bool.Parse(cmd.Parameters["@ExisteUsuario"].Value.ToString());

                }
            }
            catch (Exception)
            {

                conexionExitosa = false;
            }



            return conexionExitosa;
        }
        public Usuario ObtenerUsuario(string codigoUsuario)
        {
            Usuario _alumno = null;
            using (SqlConnection connection = new SqlConnection(conecsql))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usp_obtenerUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codigoUsuario", codigoUsuario);

                SqlDataReader sqlData = command.ExecuteReader();

                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        _alumno = new Usuario()
                        {
                            CodigoUsuario = sqlData["CodigoUsuario"].ToString(),
                            NombreUsuario = sqlData["NombreUsuario"].ToString(),
                            Intentos = int.Parse(sqlData["intentos"].ToString()),
                            Estado = sqlData["Estado"].ToString(),
                            //ContrasenaUsuario = sqlData["ContrasenaUsuario"].ToString(),
                        };
                    }
                }

            }
            return _alumno;
        }

        public string ActualizarUsuario(Usuario usuario)
        {
            string response = string.Empty;
            using (SqlConnection cn = new SqlConnection(conecsql))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_actualizarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario.CodigoUsuario);
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@contrasenaUsuario", usuario.ContrasenaUsuario);
                cmd.Parameters.AddWithValue("@intentos", usuario.ContrasenaUsuario);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                cmd.Parameters["@Mensaje"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                response = cmd.Parameters["@Mensaje"].Value.ToString();
            }
            return response;
        }
    }
}