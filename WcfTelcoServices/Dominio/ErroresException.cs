
using System.Runtime.Serialization;
namespace WcfTelcoServices.Dominio
{

    [DataContract]
    public class ErroresException
    {
        [DataMember()]
        public int Codigo { get; set; }
        [DataMember()]
        public string Descripcion { get; set; }
    }
}