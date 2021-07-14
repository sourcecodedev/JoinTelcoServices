using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JoinTelcoServicesTest.Dominio
{

    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void Test1_ValidarConexion_Caso1()
        {   //Contraseña  crorrecta
            ServiceJoinTelco.JoinTelcoServicesClient proxy = new ServiceJoinTelco.JoinTelcoServicesClient();
            ServiceJoinTelco.Usuario usuario = new ServiceJoinTelco.Usuario()
            {
                CodigoUsuario = "100001",
                ContrasenaUsuario = "123"
            };
            var response = proxy.ValidarConexion(usuario).data;

            Assert.AreEqual(true, response);
        }
        public void Test1_ValidarConexion_Caso2()
        {
            //Contraseña Incrorrecta
            ServiceJoinTelco.JoinTelcoServicesClient proxy = new ServiceJoinTelco.JoinTelcoServicesClient();
            ServiceJoinTelco.Usuario usuario = new ServiceJoinTelco.Usuario()
            {
                CodigoUsuario = "100001",
                ContrasenaUsuario = "1233"
            };
            var response = proxy.ValidarConexion(usuario).data;

            Assert.AreEqual(false, response);
        }

        public void Test2_ObtenerUsuario_Case1()
        {

        }
    }
}
