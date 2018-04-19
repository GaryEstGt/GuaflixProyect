using Guaflix.Models;
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

        public ActionResult IndexUser()
        {
            Data.instance.Usuarios.ToList().Sort();
            return View(Data.instance.Usuarios.ToList());
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
            var searchList = new List<SelectListItem>();
            searchList.Add(new SelectListItem {Value="Pelicula",Text="Pelicula" });
            searchList.Add(new SelectListItem { Value = "Show", Text = "Show" });
            searchList.Add(new SelectListItem { Value = "Documental", Text = "Documental" });
            ViewBag.SelectedList = searchList;
            return View();
        }

        // POST: Configuracion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Pelicula peli = new Pelicula(collection["Eleccion"],collection["name"],collection["year"],collection["genre"]);
                if(peli.type=="Pelicula")
                {
                    Data.instance.namePelicula.Insertar(peli);
                    Data.instance.yearPelicula.Insertar(peli);
                    Data.instance.genderPelicula.Insertar(peli);
                }
                else if (peli.type == "Show")
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
                    int grado = Convert.ToInt32(collection["filter"]);
                    Data.instance.GradoArboles = grado;
                    string direccion = collection["filter2"] + "\\";
                    Data.instance.RutaArboles = direccion;                  
                    Data.instance.namePelicula = new Biblioteca.ArbolB<Pelicula>(grado, direccion, "name.MovieTree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByName, Pelicula.CompareByYear);
                    Data.instance.yearPelicula = new Biblioteca.ArbolB<Pelicula>(grado, direccion, "year.MovieTree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByYear, Pelicula.CompareByName);
                    Data.instance.genderPelicula = new Biblioteca.ArbolB<Pelicula>(grado, direccion, "gender.MovieTree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByGenre, Pelicula.CompareByName);
                    Data.instance.nameShow = new Biblioteca.ArbolB<Pelicula>(grado, direccion, "name.ShowTree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByName, Pelicula.CompareByYear);
                    Data.instance.yearShow = new Biblioteca.ArbolB<Pelicula>(grado, direccion, "year.ShowTree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByYear, Pelicula.CompareByName);
                    Data.instance.genderShow = new Biblioteca.ArbolB<Pelicula>(grado, direccion, "gender.ShowTree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByGenre, Pelicula.CompareByName);
                    Data.instance.nameDocumental = new Biblioteca.ArbolB<Pelicula>(grado, direccion, "name.DocumentalTree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByName, Pelicula.CompareByYear);
                    Data.instance.yearDocumental = new Biblioteca.ArbolB<Pelicula>(grado, direccion, "year.DocumentalTree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByYear, Pelicula.CompareByName);
                    Data.instance.genderDocumental = new Biblioteca.ArbolB<Pelicula>(grado, direccion, "gender.DocumentalTree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullFormat, Pelicula.CompareByGenre, Pelicula.CompareByName);
                    Data.instance.Usuarios = new Biblioteca.ArbolB<Usuario>(grado, direccion, "users.Tree", Usuario.FixedSize,Usuario.ConvertToUsuario, Usuario.ToNullUsuario, Usuario.CompareByUserName, Usuario.CompareByPassword);

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
