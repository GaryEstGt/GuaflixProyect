using Guaflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guaflix.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catologo
        public ActionResult Index()
        {
            List<Pelicula> peli = new List<Pelicula>();
            return View(peli);
        }

        // GET: Catologo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult VerWL()
        {
            List<Pelicula> peli = new List<Pelicula>();
            return View(peli);
        }

        // GET: Catologo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catologo/Create
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

        // GET: Catologo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Catologo/Edit/5
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

        // GET: Catologo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Catologo/Delete/5
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
        public ActionResult buscar()
        {
            var searchList = new List<SelectListItem>();
            searchList.Add(new SelectListItem { Value = "Nombre", Text = "Nombre" });
            searchList.Add(new SelectListItem { Value = "Año", Text = "Año" });
            searchList.Add(new SelectListItem { Value = "Genero", Text = "Genero" });
            ViewBag.SelectedList = searchList;
           
            List<Pelicula> peli = new List<Pelicula>();
            return View(peli);
        }

        // POST: Catologo/Create
        [HttpPost]
        public ActionResult buscar(FormCollection collection)
        {
            try { 
                 if (collection["Eleccion"] == "Nombre")
            {

            }
            else if (collection["Eleccion"] == "Año")
            {

            }
            else
            {

            }
            
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AgregarWL()
        {
            return View();
        }

        // POST: Catologo/Create
        [HttpPost]
        public ActionResult AgregarWL(int id,FormCollection collection)
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
    }
}
