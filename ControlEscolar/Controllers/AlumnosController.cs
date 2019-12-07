using System.Web.Mvc;
using BackEnd;
using BackEnd.Repositorio;
using BackEnd.Modelos;
using System.Net;

namespace Control_Escolar.Controllers
{
    public class AlumnosController : Controller
    {
        #region REPOSITORIO
        private RepositorioAlumnos RepoAlumnos = new RepositorioAlumnos();
        #endregion
        #region VISTAS
        // GET: Alumnos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion
        #region ACTIONRESULT
        [HttpPost]
        public ActionResult Consultar_Alumnos()
        {
            var resultado = RepoAlumnos.Buscar();

            if (resultado.Status == BackEnd.Negocio.Response.ResponseStatus.Failed)
            {
                //RegistrarLog4Net(resultado.CurrentException, "BusquedaSolicitudesPendAutorizar");
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(new { success = false, message = resultado.CurrentException }, JsonRequestBehavior.AllowGet);
            }
            var jsonResult = Json(resultado.Response, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion
        #region SESSION
        private int ID_USUARIO
        {
            get
            {
                return int.Parse((System.Web.HttpContext.Current.Session["userId"] == null) ? "56162" : System.Web.HttpContext.Current.Session["userId"].ToString());
            }
        }
        #endregion
    }
}
