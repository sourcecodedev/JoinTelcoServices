 
using System.Runtime.Serialization;

namespace WcfTelcoServices.Dominio
{
    [DataContract]
    public class Plan_Servicio
    {
        [DataMember]
        public int Plan_ServicioId { get; set; }
        [DataMember]
        public string nombre_servicio { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public double precio_servicio { get; set; } 
    }
}