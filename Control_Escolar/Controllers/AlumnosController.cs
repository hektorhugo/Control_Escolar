using System.Web.Mvc;
using BackEnd;
using BackEnd.Repositorio;

namespace Control_Escolar.Controllers
{
    public class AlumnosController : Controller
    {

        // GET: Alumnos
        public ActionResult Index()
        {
            //var repo = new RepositorioAlumnos();
            //ViewBag.ProyectName = "Control Escolar";
            //ViewBag.Titulo = "ALUMNOS";
            //var dat = repo.Buscar(new Alumnos());
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
    }
}
