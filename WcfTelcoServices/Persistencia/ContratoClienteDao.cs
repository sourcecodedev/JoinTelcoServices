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
    public class ContratoClienteDao
    {
        private string conecsql = ConfigurationManager.AppSettings["connect_sql"];
        public string RegistrarContratoCliente(ContratoCliente _cliente)
        {
            string response = string.Empty;
            using (SqlConnection cn = new SqlConnection(conecsql))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_RegistrarContratoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Numerocelular", _cliente.Numerocelular);
                cmd.Parameters.AddWithValue("@Cliente_id", _cliente.Cliente_id);
                cmd.Parameters.AddWithValue("@plan_servicioId", _cliente.plan_servicioId);
                cmd.Parameters.AddWithValue("@EstadoContrato", _cliente.EstadoContrato);
                cmd.Parameters["@Mensaje"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                response = cmd.Parameters["@Mensaje"].Value.ToString();
            }
            return response;
        }

        public ContratoCliente ObtenerContratoCliente(string ContratoClienteId)
        {
            ContratoCliente _alumno = new ContratoCliente();
            using (SqlConnection connection = new SqlConnection(conecsql))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usp_obtenerContratoCliente", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ContratoClienteId", ContratoClienteId);

                SqlDataReader sqlData = command.ExecuteReader();

                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        _alumno = new ContratoCliente()
                        {
                            ContratoClienteId = int.Parse(sqlData["ContratoClienteId"].ToString()),
                            Numerocelular = sqlData["Numerocelular"].ToString(),
                            Cliente_id = int.Parse(sqlData["Cliente_id"].ToString()),
                            plan_servicioId = int.Parse(sqlData["plan_servicioId"].ToString()),
                            EstadoContrato = sqlData["EstadoContrato"].ToString(),
                            Fecha_Registro = sqlData["Fecha_Registro"].ToString(),
                        };
                    }
                }

            }
            return _alumno;
        }
        public string ModificarContratoCliente(ContratoCliente _cliente)
        {
            string response = string.Empty;
            using (SqlConnection cn = new SqlConnection(conecsql))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_ActualizarContratoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContratoClienteId", _cliente.ContratoClienteId);
                cmd.Parameters.AddWithValue("@Nombre_client", _cliente.Numerocelular);
                cmd.Parameters.AddWithValue("@Cliente_id", _cliente.Cliente_id);
                cmd.Parameters.AddWithValue("@plan_servicioId", _cliente.plan_servicioId);
                cmd.Parameters.AddWithValue("@EstadoContrato", _cliente.EstadoContrato);
                cmd.Parameters["@Mensaje"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                response = cmd.Parameters["@Mensaje"].Value.ToString();
            }
            return response;
        }
        public string EliminarContratoCliente(string ContratoClienteId)
        {
            string response = string.Empty;
            using (SqlConnection cn = new SqlConnection(conecsql))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_EliminarContratoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContratoClienteId", ContratoClienteId);
                cmd.Parameters["@Mensaje"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                response = cmd.Parameters["@Mensaje"].Value.ToString();
            }
            return response;

        }

        public List<ContratoCliente> ListarContratoCliente()
        {
            List<ContratoCliente> Lista_ContratoCliente = new List<ContratoCliente>();
            ContratoCliente _cliente = new ContratoCliente();
            using (SqlConnection connection = new SqlConnection(conecsql))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usp_ListarContratoCliente", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlData = command.ExecuteReader();

                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        _cliente = new ContratoCliente()
                        {
                            ContratoClienteId = int.Parse(sqlData["ContratoClienteId"].ToString()),
                            Numerocelular = sqlData["Numerocelular"].ToString(),
                            Cliente_id = int.Parse(sqlData["Cliente_id"].ToString()),
                            plan_servicioId = int.Parse(sqlData["plan_servicioId"].ToString()),
                            EstadoContrato = sqlData["EstadoContrato"].ToString(),
                            Fecha_Registro = sqlData["Fecha_Registro"].ToString(),
                        };
                        Lista_ContratoCliente.Add(_cliente);
                    }
                }

            }
            return Lista_ContratoCliente;
        }
    }
}