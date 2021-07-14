
using System.Runtime.Serialization;
namespace WcfTelcoServices.Utilitarios
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