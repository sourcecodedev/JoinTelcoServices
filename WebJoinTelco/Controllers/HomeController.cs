using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebJoinTelco.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ViewPlanes()
        {
            return View();
        }

        public ActionResult RegisterPlanes()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ConsultarDeudas()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}