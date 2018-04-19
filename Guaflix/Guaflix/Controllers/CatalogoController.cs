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
            foreach (var item in Data.instance.namePelicula.ToList())
            {
                peli.Add(item);
            }
            foreach (var item in Data.instance.nameShow.ToList())
            {
                peli.Add(item);
            }
            foreach (var item in Data.instance.nameDocumental.ToList())
            {
                peli.Add(item);
            }
            peli.Sort(Pelicula.CompareByName);
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
           
            
            return View(Data.instance.listaBuscados);
        }

        // POST: Catologo/Create
        [HttpPost]
        public ActionResult buscar(FormCollection collection)
        {
            
            try { 
                 if (collection["Eleccion"] == "Nombre")
            {
                    Pelicula temp = new Pelicula("", collection["filter"], collection["filter2"], "");
                    Data.instance.listaBuscados.Add(Data.instance.namePelicula.ReturnValor(temp));
                    Data.instance.listaBuscados.Add(Data.instance.nameShow.ReturnValor(temp));
                    Data.instance.listaBuscados.Add(Data.instance.nameDocumental.ReturnValor(temp));

                }
            else if (collection["Eleccion"] == "Año")
            {
                    Pelicula temp = new Pelicula("", collection["filter2"], collection["filter"], "");
                    Data.instance.listaBuscados.Add(Data.instance.yearPelicula.ReturnValor(temp));
                    Data.instance.listaBuscados.Add(Data.instance.yearShow.ReturnValor(temp));
                    Data.instance.listaBuscados.Add(Data.instance.yearDocumental.ReturnValor(temp));
                }
            else
            {
                    Pelicula temp = new Pelicula("", collection["filter2"], "", collection["filter"]);
                    Data.instance.listaBuscados.Add(Data.instance.genderPelicula.ReturnValor(temp));
                    Data.instance.listaBuscados.Add(Data.instance.genderShow.ReturnValor(temp));
                    Data.instance.listaBuscados.Add(Data.instance.genderDocumental.ReturnValor(temp));
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
