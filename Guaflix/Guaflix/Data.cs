using Biblioteca;
using Guaflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guaflix
{
    public class Data
    {
        private static Data Instance;
        public static Data instance
        {

            get
            {
                if (Instance == null)
                {
                    Instance = new Data();
                }
                return Instance;
            }
            set { Instance = value; }
        }
        public string datosUsuarios=string.Empty;
        public ArbolB<Pelicula> namePelicula;
        public ArbolB<Pelicula> yearPelicula;
        public ArbolB<Pelicula> genderPelicula;
        public ArbolB<Pelicula> nameShow;
        public ArbolB<Pelicula> yearShow;
        public ArbolB<Pelicula> genderShow;
        public ArbolB<Pelicula> nameDocumental;
        public ArbolB<Pelicula> yearDocumental;
        public ArbolB<Pelicula> genderDocumental;
        public ArbolB<Usuario> Usuarios;
        public EscribirJson escritor = new EscribirJson();
    }
}
   