using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Control_Escolar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ProyectName = "Control Escolar";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hu la la";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Hu la la";

            return View();
        }
    }
}