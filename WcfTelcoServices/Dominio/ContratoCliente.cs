 
using System.Runtime.Serialization; 

namespace WcfTelcoServices.Dominio
{
    [DataContract]
    public class ContratoCliente
    {
        [DataMember]
        public int ContratoClienteId { get; set; }
        [DataMember]
        public string Numerocelular { get; set; }
        [DataMember]
        public int Cliente_id { get; set; }
        [DataMember]
        public int plan_servicioId { get; set; }
        [DataMember]
        public string EstadoContrato { get; set; }
        [DataMember]
        public string Fecha_Registro { get; set; }
    }
}