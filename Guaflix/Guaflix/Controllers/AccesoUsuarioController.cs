using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                string redir = "Configuracion";
                if (collection["Nombre"] == "admin")
                {
                    if (collection["Contraseña"] == "admin")
                    {
                        redir="Configuracion";
                    }
                }
                else
                {

                }
                return RedirectToAction("Opciones",redir);
            }
            catch
            {
                return View();
            }
        }

    }
}
