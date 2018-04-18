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
                Pelicula peli1 = new Pelicula("D", "A", "1", "D");
                Pelicula peli2 = new Pelicula("P", "I", "2", "T");
                Pelicula peli3 = new Pelicula("P", "A", "3", "C");
                Pelicula peli4 = new Pelicula("S", "Z", "4", "C");
                Pelicula peli5 = new Pelicula("P", "A", "5", "A");
                Pelicula peli6 = new Pelicula("P", "C", "5", "F");
                Pelicula peli7 = new Pelicula("P", "T", "5", "A");
                Pelicula peli8 = new Pelicula("P", "D", "5", "R");
                Pelicula peli9 = new Pelicula("P", "K", "5", "R");
                Pelicula peli10 = new Pelicula("P", "X", "5", "M");
                Pelicula peli11 = new Pelicula("D", "M", "1", "D");
                Pelicula peli12 = new Pelicula("P", "L", "2", "T");
                Pelicula peli13 = new Pelicula("P", "B", "3", "C");
                Pelicula peli14 = new Pelicula("S", "V", "4", "C");
                Pelicula peli15 = new Pelicula("P", "Y", "5", "A");
                Pelicula peli16 = new Pelicula("P", "W", "5", "F");
                Pelicula peli17 = new Pelicula("P", "F", "5", "A");
                Pelicula peli18 = new Pelicula("P", "G", "5", "R");
                Pelicula peli19 = new Pelicula("P", "H", "5", "M");

                ArbolB<Pelicula> arbol = new ArbolB<Pelicula>(4, @"C:\Arboles\", "prueba.showtree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullPelicula);
                arbol.Insertar(peli1, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli2, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli3, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli4, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli5, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli6, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli7, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli8, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli9, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli10, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli11, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli12, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli13, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli14, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli15, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli16, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli17, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli18, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli19, Pelicula.CompareByName, Pelicula.CompareByGenre);
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
