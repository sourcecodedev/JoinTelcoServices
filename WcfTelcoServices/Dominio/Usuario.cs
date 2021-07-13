using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfTelcoServices.Dominio
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public string CodigoUsuario { get; set; }
        [DataMember]
        public string NombreUsuario { get; set; }
        [DataMember]
        public string ContrasenaUsuario { get; set; }
        [DataMember]
        public int Intentos { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Correo { get; set; }
    }
}