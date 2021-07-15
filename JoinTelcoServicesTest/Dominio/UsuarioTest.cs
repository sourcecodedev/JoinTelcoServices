using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ServiceModel;

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
        [TestMethod]
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
        [TestMethod]

        public void Test2_ObtenerUsuario_Case1()
        {
            //Obtener Usuario 100000 
            ServiceJoinTelco.JoinTelcoServicesClient proxy = new ServiceJoinTelco.JoinTelcoServicesClient();
            string codigo = "100000";

            var response = proxy.ObtenerUsuario(codigo).data;

            Assert.AreEqual("100000", response.CodigoUsuario);
            Assert.AreEqual("yhimywilbertoferia", response.NombreUsuario);
        }
        [TestMethod]
        public void Test2_ObtenerUsuario_Case2()
        {
            //Error Usuario No existe
            //Obtener Usuario 100000 
            ServiceJoinTelco.JoinTelcoServicesClient proxy = new ServiceJoinTelco.JoinTelcoServicesClient();
            string codigo = "100004";
            try
            {
                var response = proxy.ObtenerUsuario(codigo);
            }
            catch (FaultException<ServiceJoinTelco.ErroresException> error)
            {

                Assert.AreEqual(101, error.Detail.Codigo);
                Assert.AreEqual("El Usuario No Existe", error.Detail.Descripcion);
            }


            //Assert.AreEqual("100000", response.CodigoUsuario);
            //Assert.AreEqual("yhimywilbertoferia", response.NombreUsuario);
        }
    }
}

