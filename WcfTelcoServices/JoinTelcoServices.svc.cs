using System;
using System.Collections.Generic;
using System.ServiceModel;
using WcfTelcoServices.Dominio;
using WcfTelcoServices.Persistencia;
 

namespace WcfTelcoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "JoinTelcoServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione JoinTelcoServices.svc o JoinTelcoServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class JoinTelcoServices : IJoinTelcoServices
    {
        ClienteDao _clienteDao = new ClienteDao();
        ContratoClienteDao _ContratoClienteDao = new ContratoClienteDao();
        Plan_ServicioDao _Plan_ServicioDao = new Plan_ServicioDao();
        UsuarioDao _UsuarioDao = new UsuarioDao();
        public RecordResponseObject<Usuario> ActualizarUsuario(Usuario usuario)
        {

            if (_UsuarioDao.ObtenerUsuario(usuario.CodigoUsuario) == null)
            {
                throw new FaultException<ErroresException>(new ErroresException { Codigo = 101, Descripcion = "El Usuario No Existe" }
                , new FaultReason("Ocurrio un error, intento más tarde.!"));
            }
            var response_actualizar = _UsuarioDao.ActualizarUsuario(usuario);
            var response_usuario = _UsuarioDao.ObtenerUsuario(usuario.CodigoUsuario);
            return new RecordResponseObject<Usuario>(ref response_usuario) { message = response_actualizar.Trim(), success = true };
        }

        public RecordResponseObject<Usuario> ObtenerUsuario(string codigoUsuario)
        {
            if (_UsuarioDao.ObtenerUsuario(codigoUsuario) == null)
            {
                throw new FaultException<ErroresException>(new ErroresException { Codigo = 101, Descripcion = "El Usuario No Existe" }
                , new FaultReason("Ocurrio un error, intento más tarde.!"));
            }
            var response_usuario = _UsuarioDao.ObtenerUsuario(codigoUsuario);
            return new RecordResponseObject<Usuario>(ref response_usuario) { message = @"Operación éxitosa".Trim(), success = true };
        }
        public RecordResponseObject<bool> ValidarConexion(Usuario usuario)
        {
            if (_UsuarioDao.ObtenerUsuario(usuario.CodigoUsuario) == null)
            {
                throw new FaultException<ErroresException>(new ErroresException { Codigo = 101, Descripcion = "El Usuario No Existe" }
                , new FaultReason("Ocurrio un error, intento más tarde.!"));
            }
            var response = _UsuarioDao.ValidarConexion(usuario);
            return new RecordResponseObject<bool>(ref response);
        }
        public RecordResponseObject<ContratoCliente> ModificarContratoCliente(ContratoCliente contratoCliente)
        {
            if (_ContratoClienteDao.ObtenerContratoCliente(contratoCliente.ContratoClienteId.ToString()) == null)
            {
                throw new FaultException<ErroresException>(new ErroresException { Codigo = 101, Descripcion = "No Se encuentra el contrato" }
                , new FaultReason("Ocurrio un error, intento más tarde.!"));
            }
            var response_actualizar = _ContratoClienteDao.ModificarContratoCliente(contratoCliente);
            var response_usuario = _ContratoClienteDao.ObtenerContratoCliente(contratoCliente.ContratoClienteId.ToString());
            return new RecordResponseObject<ContratoCliente>(ref response_usuario) { message = response_actualizar.Trim(), success = true };
        }
        public RecordResponseObject<List<ContratoCliente>> ListarContratoCliente()
        {
            var response_Contrato = _ContratoClienteDao.ListarContratoCliente();
            return new RecordResponseObject<List<ContratoCliente>>(ref response_Contrato) { message = "Operación Exitosa", success = true };
        }

        public RecordResponseObject<ContratoCliente> ObtenerContratoCliente(string ContratoClienteId)
        {
            if (_ContratoClienteDao.ObtenerContratoCliente(ContratoClienteId) == null)
            {
                throw new FaultException<ErroresException>(new ErroresException { Codigo = 101, Descripcion = "El contrato No Existe" }
                , new FaultReason("Ocurrio un error, intento más tarde.!"));
            }
            var response_contrato = _ContratoClienteDao.ObtenerContratoCliente(ContratoClienteId);
            return new RecordResponseObject<ContratoCliente>(ref response_contrato) { message = @"Operación éxitosa".Trim(), success = true };
        }
        public RecordResponseObject<string> EliminarContratoCliente(string ContratoClienteId)
        {
            if (_ContratoClienteDao.ObtenerContratoCliente(ContratoClienteId) == null)
            {
                throw new FaultException<ErroresException>(new ErroresException { Codigo = 101, Descripcion = "El contrato No Existe" }
                , new FaultReason("Ocurrio un error, intento más tarde.!"));
            }
            var response_contrato = _ContratoClienteDao.EliminarContratoCliente(ContratoClienteId);
            return new RecordResponseObject<string>(ref response_contrato) { message = @"Operación éxitosa".Trim(), success = true };
        }
        public RecordResponseObject<Plan_Servicio> ObtenerPlanServiciobyId(int codigoPlanServicio)
        {
            if (_Plan_ServicioDao.ObtenerPlanServiciobyId(codigoPlanServicio) == null)
            {
                throw new FaultException<ErroresException>(new ErroresException { Codigo = 101, Descripcion = "El Plan de servicios No Existe" }
                , new FaultReason("Ocurrio un error, intento más tarde.!"));
            }
            var response_contrato = _Plan_ServicioDao.ObtenerPlanServiciobyId(codigoPlanServicio);
            return new RecordResponseObject<Plan_Servicio>(ref response_contrato) { message = @"Operación éxitosa".Trim(), success = true };
        }


        public RecordResponseObject<List<Cliente>> ListarCliente()
        {
            var response_contrato = _clienteDao.ListarCliente();
            return new RecordResponseObject<List<Cliente>>(ref response_contrato) { message = @"Operación éxitosa".Trim(), success = true };
        }

        public RecordResponseObject<string> EliminarCliente(string Num_documento)
        {
            if (_clienteDao.ObtenerCliente(Num_documento) == null)
            {
                throw new FaultException<ErroresException>(new ErroresException { Codigo = 101, Descripcion = "El Cliente No Existe" }
                , new FaultReason("Ocurrio un error, intento más tarde.!"));
            }
            var response_contrato = _clienteDao.EliminarCliente(Num_documento);
            return new RecordResponseObject<string>(ref response_contrato) { message = @"Operación éxitosa".Trim(), success = true };
        }

        public RecordResponseObject<Cliente> ModificarCliente(Cliente _cliente)
        {
            if (_clienteDao.ObtenerCliente(_cliente.Num_documento) == null)
            {
                throw new FaultException<ErroresException>(new ErroresException { Codigo = 101, Descripcion = "El Cliente No Existe" }
                , new FaultReason("Ocurrio un error, intento más tarde.!"));
            }
            var response_actualizar = _clienteDao.ModificarCliente(_cliente);
            var response_cliente = _clienteDao.ObtenerCliente(_cliente.Num_documento);
            return new RecordResponseObject<Cliente>(ref response_cliente) { message = response_actualizar.Trim(), success = true };
        }



        public RecordResponseObject<Cliente> ObtenerCliente(string Num_documento)
        {
            if (_clienteDao.ObtenerCliente(Num_documento) == null)
            {
                throw new FaultException<ErroresException>(new ErroresException { Codigo = 101, Descripcion = "El Cliente No Existe" }
                , new FaultReason("Ocurrio un error, intento más tarde.!"));
            }
            var response_contrato = _clienteDao.ObtenerCliente(Num_documento);
            return new RecordResponseObject<Cliente>(ref response_contrato) { message = @"Operación éxitosa".Trim(), success = true };
        }

        public RecordResponseObject<List<Plan_Servicio>> ObtenerPlanServicios()
        {
            var response_contrato = _Plan_ServicioDao.ObtenerPlanServicios();
            return new RecordResponseObject<List<Plan_Servicio>>(ref response_contrato) { message = @"Operación éxitosa".Trim(), success = true };
        }



        public RecordResponseObject<Cliente> RegistrarCliente(Cliente _cliente)
        {
            if (_clienteDao.ObtenerCliente(_cliente.Num_documento) == null)
            {
                throw new FaultException<ErroresException>(new ErroresException { Codigo = 101, Descripcion = "El Cliente No Existe" }
                , new FaultReason("Ocurrio un error, intento más tarde.!"));
            }
            var response_actualizar = _clienteDao.RegistrarCliente(_cliente);
            var response_cliente = _clienteDao.ObtenerCliente(_cliente.Num_documento);
            return new RecordResponseObject<Cliente>(ref response_cliente) { message = response_actualizar.Trim(), success = true };
        }

        public RecordResponseObject<ContratoCliente> RegistrarContratoCliente(ContratoCliente contratoCliente)
        {
            if (_ContratoClienteDao.ObtenerContratoCliente(contratoCliente.ContratoClienteId.ToString()) == null)
            {
                throw new FaultException<ErroresException>(new ErroresException { Codigo = 101, Descripcion = "El Contrato No Existe" }
                , new FaultReason("Ocurrio un error, intento más tarde.!"));
            }
            var response_actualizar = _ContratoClienteDao.RegistrarContratoCliente(contratoCliente);
            var response_cliente = _ContratoClienteDao.ObtenerContratoCliente(contratoCliente.ContratoClienteId.ToString());
            return new RecordResponseObject<ContratoCliente>(ref response_cliente) { message = response_actualizar.Trim(), success = true };
        }


    }
}
