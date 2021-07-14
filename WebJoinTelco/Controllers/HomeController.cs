using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebJoinTelco.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ConsultarDeudas()
        {
            return View();
        }

        public ActionResult DeleteContratoCliente()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ModificarContratoCliente()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RegistarContratoCliente()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ListarContratoClientes()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}