using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca;
using Guaflix.Models;
using System.Web.Security;

namespace Guaflix.Controllers
{
    public class AccesoUsuarioController : Controller
    {
        // GET: AccesoUsuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccesoUsuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccesoUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccesoUsuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string redirigir = "LogIn";
                
                 
                return RedirectToAction(redirigir);
            }
            catch
            {
                return View();
            }
        }

        // GET: AccesoUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccesoUsuario/Edit/5
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

        // GET: AccesoUsuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccesoUsuario/Delete/5
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
        public ActionResult LogIn()
        {
            return View();
        }

        // POST: AccesoUsuario/Delete/5
        [HttpPost]
        public ActionResult LogIn(FormCollection collection)
        {
            try
            {
                Pelicula peli1 = new Pelicula("Documental", "Albert Einstein", "2015", "Documental");
                Pelicula peli2 = new Pelicula("Pelicula", "Insidious", "2013", "Terror");
                Pelicula peli3 = new Pelicula("Pelicula", "Anastasia", "2014", "Comedia");
                Pelicula peli4 = new Pelicula("Serie", "Zoo", "2011", "Comedia");                
                ArbolB<Pelicula> arbol = new ArbolB<Pelicula>(5, @"C:\Arboles\", "prueba.showtree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullPelicula);
                arbol.Insertar(peli1, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli2, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli3, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli4, Pelicula.CompareByName, Pelicula.CompareByGenre);                
                string redir = "Configuracion";
                string redir2 = "Opciones";
                if (collection["userName"] == "admin")
                {
                    if (collection["password"] == "admin")
                    {
                        redir="Configuracion";
                    }
                }
                else
                {
                    redir = "Catalogo";
                    redir2 = "Index";
                }
                return RedirectToAction(redir2,redir);
            }
            catch(Exception e)
            {                
                return View();
            }
        }
        public ActionResult LogOut()
        {
            return View();
        }

        // POST: AccesoUsuario/Delete/5
        [HttpPost]
        public ActionResult LogOut(FormCollection collection)
        {
            try
            {
                FormsAuthentication.SignOut();
                Session.Abandon();

                return RedirectToAction("LogIn");
            }
            catch
            {
                return View();
            }
        }

    }
}
