using System.Configuration;
using WcfTelcoServices.Dominio;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace WcfTelcoServices.Persistencia
{
    public class ClienteDao
    {
        private string conecsql = ConfigurationManager.AppSettings["connect_sql"];

        public string RegistrarCliente(Cliente _cliente)
        {
            string response = string.Empty;
            using (SqlConnection cn = new SqlConnection(conecsql))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_registrarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_client", _cliente.Nombre_client);
                cmd.Parameters.AddWithValue("@Num_documento", _cliente.Num_documento);
                cmd.Parameters.AddWithValue("@CantidadLineas", _cliente.CantidadLineas);
                cmd.Parameters.AddWithValue("@EstadoCliente", _cliente.EstadoCliente); 
                cmd.Parameters["@Mensaje"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                response = cmd.Parameters["@Mensaje"].Value.ToString();
            }
            return response;
        }
        public Cliente ObtenerCliente(string @Num_documento)
        {
            Cliente _alumno =  new Cliente();
            using (SqlConnection connection = new SqlConnection(conecsql))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usp_obtenerUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Num_documento", @Num_documento);

                SqlDataReader sqlData = command.ExecuteReader();
         
                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        _alumno = new Cliente()
                        {
                            clienteId = int.Parse(sqlData["clienteId"].ToString()),
                            Nombre_client = sqlData["Nombre_client"].ToString(),
                            Num_documento = sqlData["Num_documento"].ToString(),
                            CantidadLineas = int.Parse(sqlData["CantidadLineas"].ToString()),
                            EstadoCliente = sqlData["EstadoCliente"].ToString(),
                            //ContrasenaUsuario = sqlData["ContrasenaUsuario"].ToString(),
                        };
                    }
                }

            }
            return _alumno;
        }
        public string ModificarCliente(Cliente _cliente)
        {
            string response = string.Empty;
            using (SqlConnection cn = new SqlConnection(conecsql))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_actualiazarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clienteId", _cliente.clienteId);
                cmd.Parameters.AddWithValue("@Nombre_client", _cliente.Nombre_client);
                cmd.Parameters.AddWithValue("@Num_documento", _cliente.Num_documento);
                cmd.Parameters.AddWithValue("@CantidadLineas", _cliente.CantidadLineas);
                cmd.Parameters.AddWithValue("@EstadoCliente", _cliente.EstadoCliente);
                cmd.Parameters["@Mensaje"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                response = cmd.Parameters["@Mensaje"].Value.ToString();
            }
            return response;
        }
        public string EliminarCliente(string numero_documento)
        {
            string response = string.Empty;
            using (SqlConnection cn = new SqlConnection(conecsql))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_EliminarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_documento", numero_documento);
                cmd.Parameters["@Mensaje"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                response = cmd.Parameters["@Mensaje"].Value.ToString();
            }
            return response;

        }

        public List<Cliente> ListarCliente()
        {
            List<Cliente> Lista_cliente = new List<Cliente>();
            Cliente _cliente = new Cliente();
            using (SqlConnection connection = new SqlConnection(conecsql))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usp_obtenerUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                SqlDataReader sqlData = command.ExecuteReader();

                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        _cliente = new Cliente()
                        {
                            clienteId = int.Parse(sqlData["clienteId"].ToString()),
                            Nombre_client = sqlData["Nombre_client"].ToString(),
                            Num_documento = sqlData["Num_documento"].ToString(),
                            CantidadLineas = int.Parse(sqlData["CantidadLineas"].ToString()),
                            EstadoCliente = sqlData["EstadoCliente"].ToString(),
                            //ContrasenaUsuario = sqlData["ContrasenaUsuario"].ToString(),
                        };
                        Lista_cliente.Add(_cliente);
                    }
                }

            }
            return Lista_cliente;
        }
    }
}