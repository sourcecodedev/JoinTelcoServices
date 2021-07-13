using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WcfTelcoServices.Dominio;
using System.Data;
using System.Data.SqlClient;
namespace WcfTelcoServices.Persistencia
{
    public class Plan_ServicioDao
    {
        private string conecsql = ConfigurationManager.AppSettings["connect_sql"];


        public Plan_Servicio ObtenerPlanServiciobyId(int codigoPlanServicio)
        {

            Plan_Servicio plan_Servicio = new Plan_Servicio();


            using (SqlConnection cn = new SqlConnection(conecsql))
            {
                cn.Open();
                SqlCommand command = new SqlCommand("usp_obtenerPlanServicioByid", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Plan_ServicioId", codigoPlanServicio);

                SqlDataReader sqlData = command.ExecuteReader();

                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        plan_Servicio = new Plan_Servicio()
                        {
                            Plan_ServicioId = (int.Parse(sqlData["CodigoUsuario"].ToString())),
                            nombre_servicio = sqlData["nombre_servicio"].ToString(),
                            descripcion = sqlData["descripcion"].ToString(),
                            precio_servicio = double.Parse(sqlData["precio_servicio"].ToString())
                        };
                    }
                }
            }
            return plan_Servicio;
        }
        public List<Plan_Servicio> ObtenerPlanServicios()
        {
            List<Plan_Servicio> lista_plan_Servicio = new List<Plan_Servicio>();
            Plan_Servicio plan_Servicio = new Plan_Servicio();


            using (SqlConnection cn = new SqlConnection(conecsql))
            {
                cn.Open();
                SqlCommand command = new SqlCommand("usp_obtenerPlanServicios", cn);
                command.CommandType = CommandType.StoredProcedure;
                

                SqlDataReader sqlData = command.ExecuteReader();

                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        plan_Servicio = new Plan_Servicio()
                        {
                            Plan_ServicioId = (int.Parse(sqlData["CodigoUsuario"].ToString())),
                            nombre_servicio = sqlData["nombre_servicio"].ToString(),
                            descripcion = sqlData["descripcion"].ToString(),
                            precio_servicio = double.Parse(sqlData["precio_servicio"].ToString())
                        };
                        lista_plan_Servicio.Add(plan_Servicio);
                    }
                }
            }
            return lista_plan_Servicio;
        }
    }
}