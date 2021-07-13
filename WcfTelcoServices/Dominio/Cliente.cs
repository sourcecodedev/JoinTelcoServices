 
using System.Runtime.Serialization; 

namespace WcfTelcoServices.Dominio
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int clienteId { get; set; }
        [DataMember]
        public string Nombre_client { get; set; }
        [DataMember]
        public string Num_documento { get; set; }
        [DataMember]
        public int CantidadLineas { get; set; }
        [DataMember]
        public string EstadoCliente { get; set; }
    }
}