using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca;
using Guaflix.Models;

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
                
                    if(collection["password"].ToString().Count() < 6)
                    {
                        TempData["alertMessage"] = "la contraseña debe tener al menos 8 carácteres";
                        redirigir = "Create";
                    }
                    else
                    {
                        if (collection["password"] == collection["Cpassword"])
                        {
                            redirigir = "LogIn";
                        }
                    }
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
                //NodoB<Pelicula> nodo = new NodoB<Pelicula>(peli.FixedSizeText, 5) {posicion = 1};
                //nodo.Valores[0] = peli;
                //BWriter<Pelicula>.EscribirRaiz("prueba.txt", "00000000001");
                //BWriter<Pelicula>.EscribirPosicionDisponible("prueba.txt", "00000000002");
                //BWriter<Pelicula>.EscribirNodo("prueba.txt", nodo, 1);
                //int raiz = 0, posicion = 0;
                //BReader<Pelicula>.LeerRaiz("prueba.txt", ref raiz);
                //BReader<Pelicula>.LeerPosicionDisponible("prueba.txt", ref posicion);
                //string Nodo = BReader<Pelicula>.LeerNodo("prueba.txt", 1);

                ArbolB<Pelicula> arbol = new ArbolB<Pelicula>(5, @"C:\Arboles\", "prueba.showtree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullPelicula);
                arbol.Insertar(peli1, Pelicula.CompareByName, Pelicula.CompareByGenre);
                arbol.Insertar(peli2, Pelicula.CompareByName, Pelicula.CompareByGenre);
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

    }
}
