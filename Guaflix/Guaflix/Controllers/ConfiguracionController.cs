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
        public ActionResult Opciones(string submitButton, HttpPostedFileBase postedFile, FormCollection collection)
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
                Pelicula peli = new Pelicula(collection["type"],collection["name"],collection["year"],collection["genre"]);
                if(peli.type=="Pelicula"||peli.type=="pelicula"|| peli.type == "Película" || peli.type == "película" || peli.type == "PELICULA" || peli.type == "PELÍCULA")
                {
                    Data.instance.namePelicula.Insertar(peli);
                    Data.instance.yearPelicula.Insertar(peli);
                    Data.instance.genderPelicula.Insertar(peli);
                }
                else if (peli.type == "Show" || peli.type == "Serie" || peli.type == "serie" || peli.type == "show")
                {
                    Data.instance.nameShow.Insertar(peli);
                    Data.instance.yearShow.Insertar(peli);
                    Data.instance.genderShow.Insertar(peli);
                }
                else
                {
                    Data.instance.nameDocumental.Insertar(peli);
                    Data.instance.yearDocumental.Insertar(peli);
                    Data.instance.genderDocumental.Insertar(peli);
                }

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
                Usuario temp = new Usuario(collection["nombre"], collection["apellido"], Convert.ToInt32(collection["edad"]), collection["username"], collection["password"], collection["password"]);

                if (Data.instance.datosUsuarios == string.Empty)
                {
                    Data.instance.datosUsuarios = JsonConvert.SerializeObject(temp);
                }
                else
                {
                    Data.instance.datosUsuarios += "," + JsonConvert.SerializeObject(temp);
                }
                Data.instance.escritor.EscribirArchivo(Data.instance.datosUsuarios);
                Data.instance.Usuarios.Insertar(temp);
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
                    for (int i = 0; i < pelis.Length-1; i++)
                    {
                        if (pelis[i].type == "Pelicula" || pelis[i].type == "pelicula" || pelis[i].type == "Película" || pelis[i].type == "película" || pelis[i].type == "PELICULA" || pelis[i].type == "PELÍCULA")
                        {
                            Data.instance.namePelicula.Insertar(pelis[i]);
                            Data.instance.yearPelicula.Insertar(pelis[i]);
                            Data.instance.genderPelicula.Insertar(pelis[i]);
                        }
                        else if (pelis[i].type == "Show" || pelis[i].type == "Serie" || pelis[i].type == "serie" || pelis[i].type == "show")
                        {
                            Data.instance.nameShow.Insertar(pelis[i]);
                            Data.instance.yearShow.Insertar(pelis[i]);
                            Data.instance.genderShow.Insertar(pelis[i]);
                        }
                        else
                        {
                            Data.instance.nameDocumental.Insertar(pelis[i]);
                            Data.instance.yearDocumental.Insertar(pelis[i]);
                            Data.instance.genderDocumental.Insertar(pelis[i]);
                        }
                    }
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
        public ActionResult CargarArchivo(HttpPostedFileBase postedFile)
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
                    Usuario[] usuariosCargados = JsonConvert.DeserializeObject<Usuario[]>(csvData);
                }

                return RedirectToAction("IndexUser");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult InicioApp()
        {
            return View();

        }
        [HttpPost]
        public ActionResult InicioApp(string submitButton,FormCollection collection)
        {
            try
            {
                string redireccionarAccion="";
                string redireccionarController="";
                if (submitButton == "Iniciar App")
                {
                    int filterValue = Convert.ToInt32(collection["filter"]);
                    string direccion = collection["filter2"] + "\\";                    
                    Data.instance.namePelicula = new Biblioteca.ArbolB<Pelicula>(filterValue, direccion, "nameMovie", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByName, Pelicula.CompareByYear);
                    Data.instance.yearPelicula = new Biblioteca.ArbolB<Pelicula>(filterValue, direccion, "yearMovie", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByYear, Pelicula.CompareByName);
                    Data.instance.genderPelicula = new Biblioteca.ArbolB<Pelicula>(filterValue, direccion, "genderMovie", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByGenre, Pelicula.CompareByName);
                    Data.instance.nameShow = new Biblioteca.ArbolB<Pelicula>(filterValue, direccion, "nameShow", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByName, Pelicula.CompareByYear);
                    Data.instance.yearShow = new Biblioteca.ArbolB<Pelicula>(filterValue, direccion, "yearShow", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByYear, Pelicula.CompareByName);
                    Data.instance.genderShow = new Biblioteca.ArbolB<Pelicula>(filterValue, direccion, "genderShow", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByGenre, Pelicula.CompareByName);
                    Data.instance.nameDocumental = new Biblioteca.ArbolB<Pelicula>(filterValue, direccion, "nameDocumental", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByName, Pelicula.CompareByYear);
                    Data.instance.yearDocumental = new Biblioteca.ArbolB<Pelicula>(filterValue, direccion, "yearDocumental", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByYear, Pelicula.CompareByName);
                    Data.instance.genderDocumental = new Biblioteca.ArbolB<Pelicula>(filterValue, direccion, "genderDocumental", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByGenre, Pelicula.CompareByName);
                    Data.instance.Usuarios = new Biblioteca.ArbolB<Usuario>(filterValue, direccion, "Usuarios", Usuario.FixedSize,Usuario.ConvertToUsuario, Usuario.ToNullUsuario, Usuario.CompareByUserName, Usuario.CompareByPassword);

                    redireccionarAccion = "LogIn";
                    redireccionarController = "AccesoUsuario";
                }else
                {
                    redireccionarAccion = "Opciones";
                    redireccionarController = "Configuracion";
                }

                return RedirectToAction(redireccionarAccion,redireccionarController);
            }
            catch
            {
                return View();
            }
        }
    }
}
