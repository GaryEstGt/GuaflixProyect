﻿using Guaflix.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guaflix.Controllers
{
    public class ConfiguracionController : Controller
    {
        // GET: Configuracion
        public ActionResult Index()
        {
            List<Pelicula> pelis = new List<Pelicula>();
            return View(pelis);
        }

        public ActionResult IndexUser()
        {
            List<Usuario> usuarios = new List<Usuario>();
            return View(usuarios);
        }
        public ActionResult Opciones()
        {
            //variable que guarda ruta a direccionar
           
            return View();
        }
        [HttpPost]
        public ActionResult Opciones(string submitButton)
        {
            try
            {
                // TODO: Add insert logic here
                string red = "Index";
                if (submitButton == "Editar Usuarios")
                {
                    red = "IndexUser";
                }

                return RedirectToAction(red);
            }
            catch
            {
                return View();
            }
        }

        // GET: Configuracion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Configuracion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Configuracion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: Configuracion/Create
        [HttpPost]
        public ActionResult CreateUser(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("IndexUser");
            }
            catch
            {
                return View();
            }
        }

        // GET: Configuracion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Configuracion/Edit/5
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

        // GET: Configuracion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Configuracion/Delete/5
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
        public ActionResult CrearArchivo()
        {
            return View();
        }

        // POST: Configuracion/Create
        [HttpPost]
        public ActionResult CrearArchivo(HttpPostedFileBase postedFile)
        {
            try
            {

                string todoeltexto = "";
                string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    int contLinea = 0;
                    string csvData = System.IO.File.ReadAllText(filePath);
                    /* foreach (string row in csvData.Split('}'))
                     {*/


                    /* if (!string.IsNullOrEmpty(row))
                     {*/
                    Pelicula[] pelis = JsonConvert.DeserializeObject<Pelicula[]>(csvData);
                }
                        
                       
                       


                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CargarArchivo()
        {
            return View();
        }

        // POST: Configuracion/Create
        [HttpPost]
        public ActionResult CargarArchivo(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("IndexUser");
            }
            catch
            {
                return View();
            }
        }
    }
}