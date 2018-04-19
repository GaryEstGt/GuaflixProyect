using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca;
using Guaflix.Models;
using System.Web.Security;
using Newtonsoft.Json;

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
                Pelicula peli1 = new Pelicula("D", "A", "1", "D");
                Data.instance.nameDocumental.Insertar(peli1);
                string redirigir = "LogIn";
                
                 
                return RedirectToAction(redirigir);
            }
            catch(Exception e)
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
                string redir2 = "Opciones";
                if (collection["username"] == "admin")
                {
                    if (collection["password"] == "admin")
                    {
                        redir="Configuracion";
                    }
                }
                else
                {                    
                    redir2 = "Index";
                    redir = "Catalogo";
                    Usuario user = new Usuario("", "", 0, collection["username"], collection["password"], collection["password"]);
                    Usuario user1 = Data.instance.Usuarios.ReturnValor(user);
                    if (user1 != null)
                    {
                        if (user1.password == collection["password"])
                        {
                            redir = "catalogo";
                        }
                        else
                        {
                            TempData["Mensaje"] = "Contraseña equivocada";
                        }
                    }
                    else
                    {
                        TempData["Mensaje"] = "Usuario equivocado";
                        redir2 = "LogIn";
                        redir = "AccesoUsuario";
                    }
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
        public ActionResult EleccionGrado()
        {
            return View();
        }

        // POST: AccesoUsuario/Create
        [HttpPost]
        public ActionResult EleccionGrado(FormCollection collection)
        {
            try
            {
               
                string direccion = collection["filter2"];
                string nombre = collection["filter3"];
               //ArbolB<Pelicula> arbol = new ArbolB<Pelicula>(filterValue, @direccion+"/", nombre+".showtree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullPelicula);
                return RedirectToAction("LogIn");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult LogInAdmin()
        {
            return View();
        }

        // POST: AccesoUsuario/Delete/5
        [HttpPost]
        public ActionResult LogInAdmin(FormCollection collection)
        {
            try
            {
                //Pelicula peli1 = new Pelicula("D", "A", "1", "D");
                //Pelicula peli2 = new Pelicula("P", "I", "2", "T");
                //Pelicula peli3 = new Pelicula("P", "A", "3", "C");
                //Pelicula peli4 = new Pelicula("S", "Z", "4", "C");
                //Pelicula peli5 = new Pelicula("P", "A", "5", "A");
                //Pelicula peli6 = new Pelicula("P", "C", "5", "F");
                //Pelicula peli7 = new Pelicula("P", "T", "5", "A");
                //Pelicula peli8 = new Pelicula("P", "D", "5", "R");
                //Pelicula peli9 = new Pelicula("P", "K", "5", "R");
                //Pelicula peli10 = new Pelicula("P", "X", "5", "M");
                //Pelicula peli11 = new Pelicula("D", "M", "1", "D");
                //Pelicula peli12 = new Pelicula("P", "L", "2", "T");
                //Pelicula peli13 = new Pelicula("P", "B", "3", "C");
                //Pelicula peli14 = new Pelicula("S", "V", "4", "C");
                //Pelicula peli15 = new Pelicula("P", "Y", "5", "A");
                //Pelicula peli16 = new Pelicula("P", "W", "5", "F");
                //Pelicula peli17 = new Pelicula("P", "F", "5", "A");
                //Pelicula peli18 = new Pelicula("P", "G", "5", "R");
                //Pelicula peli19 = new Pelicula("P", "H", "5", "M");

                //ArbolB<Pelicula> arbol = new ArbolB<Pelicula>(4, @"C:\Arboles\", "prueba.showtree", Pelicula.FixedSize, Pelicula.ConvertToPelicula, Pelicula.ToNullPelicula, Pelicula.CompareByName, Pelicula.CompareByYear);
                //arbol.Insertar(peli1);
                //arbol.Insertar(peli2);
                //arbol.Insertar(peli3);
                //arbol.Insertar(peli4);
                //arbol.Insertar(peli5);
                //arbol.Insertar(peli6);
                //arbol.Insertar(peli7);
                //arbol.Insertar(peli8);
                //arbol.Insertar(peli9);
                //arbol.Insertar(peli10);
                //arbol.Insertar(peli11);
                //arbol.Insertar(peli12);
                //arbol.Insertar(peli13);
                //arbol.Insertar(peli14);
                //arbol.Insertar(peli15);
                //arbol.Insertar(peli16);
                //arbol.Insertar(peli17);
                //arbol.Insertar(peli18);
                //arbol.Insertar(peli19);

                //List<Pelicula> peliculas = arbol.ToList();
                //peliculas.Sort(Pelicula.CompareByName);
                //Usuario us1 = new Usuario("a", "a", 4, "a", "a", "b");
                //Usuario us2 = new Usuario("a", "a", 4, "b", "b", "b");
                //Usuario us3 = new Usuario("a", "a", 4, "c", "c", "b");
                //Usuario us4 = new Usuario("a", "a", 4, "d", "d", "b");
                //Usuario us5 = new Usuario("a", "a", 4, "e", "e", "b");
                //Usuario us6 = new Usuario("a", "a", 4, "f", "f", "b");
                //Usuario us7 = new Usuario("a", "a", 4, "g", "g", "b");
                //Usuario us8 = new Usuario("a", "a", 4, "h", "h", "b");
                //Usuario us9 = new Usuario("a", "a", 4, "i", "i", "b");
                //Usuario us10 = new Usuario("a", "a", 4, "j", "j", "b");

                //ArbolB<Usuario> arbol = new ArbolB<Usuario>(4, @"C:\Arboles\", "usuariosPrueba.tree", Usuario.FixedSize, Usuario.ConvertToUsuario, Usuario.ToNullFormat, Usuario.CompareByUserName, Usuario.CompareByPassword);

                //arbol.Insertar(us1);
                //arbol.Insertar(us2);
                //arbol.Insertar(us3);
                //arbol.Insertar(us4);
                //arbol.Insertar(us5);
                //arbol.Insertar(us6);
                //arbol.Insertar(us7);
                //arbol.Insertar(us8);
                //arbol.Insertar(us9);
                //arbol.Insertar(us10);

                string redir = "Configuracion";
                string redir2 = "InicioApp";
                if (collection["username"] == "admin")
                {
                    if (collection["password"] == "admin")
                    {
                        redir = "Configuracion";
                    }
                }
                else
                {
                    TempData["Mensaje"] = "Debe ingresar el administrador para usar la aplicación";
                    redir2 = "LogInAdmin";
                    redir = "AccesoUsuario";
                }
                return RedirectToAction(redir2, redir);
            }
            catch (Exception e)
            {
                return View();
            }
        }

    }
}
