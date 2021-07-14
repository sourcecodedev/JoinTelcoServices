using System;
using System.Collections.Generic;
using System.ServiceModel;
using WcfTelcoServices.Dominio;
using WcfTelcoServices.Utilitarios;
using static WcfTelcoServices.Dominio.Response;

namespace WcfTelcoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IJoinTelcoServices" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IJoinTelcoServices
    {
        [FaultContract(typeof(Plan_Servicio))]

        #region Response Cliente Servicios
        [OperationContract]
        RecordResponseObject<Cliente> RegistrarCliente(Cliente _cliente);
        [OperationContract]
        RecordResponseObject<Cliente> ObtenerCliente(string @Num_documento);
        [OperationContract]
        RecordResponseObject<Cliente> ModificarCliente(Cliente _cliente);
        [OperationContract]
        RecordResponseObject<string> EliminarCliente(string @Num_documento);
        [OperationContract]
        RecordResponseObject<List<Cliente>> ListarCliente();
        #endregion

        #region Response Contrato Cliente Servicios
        [OperationContract]
        RecordResponseObject<ContratoCliente> RegistrarContratoCliente(ContratoCliente contratoCliente);
        [OperationContract]
        RecordResponseObject<ContratoCliente> ObtenerContratoCliente(string ContratoClienteId);
        [OperationContract]
        RecordResponseObject<ContratoCliente> ModificarContratoCliente(ContratoCliente contratoCliente);
        [OperationContract]
        RecordResponseObject<string> EliminarContratoCliente(string ContratoClienteId);
        [OperationContract]
        RecordResponseObject<List<ContratoCliente>> ListarContratoCliente();
        #endregion

        #region Response Planes Servicios
        [OperationContract]
        RecordResponseObject<Plan_Servicio> ObtenerPlanServiciobyId(int codigoPlanServicio);
        [OperationContract]
        RecordResponseObject<List<Plan_Servicio>> ObtenerPlanServicios();
        #endregion

        #region Response Usuario Servicios
        [OperationContract]
        RecordResponseObject<bool> ValidarConexion(Usuario usuario);
        [OperationContract]
        RecordResponseObject<Usuario> ObtenerUsuario(string codigoUsuario);
        [OperationContract]
        RecordResponseObject<Usuario> ActualizarUsuario(Usuario usuario);
        #endregion
    }
}
