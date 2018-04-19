using Guaflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Biblioteca;

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
            Data.instance.usuarioenSesion.WatchList.ToList().Sort(Pelicula.CompareByName);
            return View(Data.instance.usuarioenSesion.WatchList.ToList());
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
        public ActionResult Delete(string tipo, string nombre, string año)
        {
            return View();
        }

        // POST: Catologo/Delete/5
        [HttpPost]
        public ActionResult Delete(string tipo, string nombre, string año, FormCollection collection)
        {
            try
            {                
                Pelicula peli = new Pelicula(tipo, nombre, año, "");
                List<Pelicula> lista = new List<Pelicula>();
                switch (tipo)
                {
                    case "Show":
                        lista = Data.instance.usuarioenSesion.WatchList.Eliminar(Data.instance.nameShow.ReturnValor(peli));                        
                        System.IO.File.Delete(Data.instance.usuarioenSesion.WatchList.RutaArbol);                        
                        break;
                    case "Pelicula":
                        lista = Data.instance.usuarioenSesion.WatchList.Eliminar(Data.instance.namePelicula.ReturnValor(peli));
                        System.IO.File.Delete(Data.instance.namePelicula.RutaArbol);
                        break;
                    case "Documental":
                        lista = Data.instance.usuarioenSesion.WatchList.Eliminar(Data.instance.nameDocumental.ReturnValor(peli));
                        System.IO.File.Delete(Data.instance.nameDocumental.RutaArbol);
                        break;
                }

                Data.instance.usuarioenSesion.WatchList = new ArbolB<Pelicula>(Data.instance.GradoArboles, Data.instance.RutaArboles + "WatchLists\\", Data.instance.usuarioenSesion.username + ".watchlist", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByName, Pelicula.CompareByYear);

                for (int i = 0; i < lista.Count; i++)
                {
                    Data.instance.usuarioenSesion.WatchList.Insertar(lista[i]);
                }
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

                return RedirectToAction("buscar");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AgregarWL(string tipo, string name, string year)
        {
            return View();
        }

        // POST: Catologo/Create
        [HttpPost]
        public ActionResult AgregarWL(string tipo, string name, string year, FormCollection collection)
        {
            try
            {
                Pelicula peli = new Pelicula(tipo, name, year, "");
                switch (tipo)
                {
                    case "Show":
                        Data.instance.usuarioenSesion.WatchList.Insertar(Data.instance.nameShow.ReturnValor(peli));
                        break;
                    case "Pelicula":
                        Data.instance.usuarioenSesion.WatchList.Insertar(Data.instance.namePelicula.ReturnValor(peli));
                        break;
                    case "Documental":
                        Data.instance.usuarioenSesion.WatchList.Insertar(Data.instance.nameDocumental.ReturnValor(peli));
                        break;
                }
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
