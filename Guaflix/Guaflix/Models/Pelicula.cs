using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guaflix.Models
{
    public class Pelicula
    {
        public string tipo { get; set; }
        public string nombre { get; set; }
        public string añoLanzamiento { get; set; }
        public string genero { get; set; }
    }
}