using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biblioteca;

namespace Guaflix.Models
{
    public class Pelicula : IFixedSizeText
    {
        public string tipo { get; set; }
        public string nombre { get; set; }
        public string añoLanzamiento { get; set; }
        public string genero { get; set; }
        public Pelicula(string Tipo, string Nombre, string Año, string Genero)
        {
            tipo = Tipo;
            nombre = Nombre;
            añoLanzamiento = Año;
            genero = Genero;
            FixedSize = 93;
            FixedSizeText = FixedSize;
        }
        public int FixedSizeText { get; set; }
        public static int FixedSize { get; set; }
        public string ToFixedSizeString()
        {
            return $"{string.Format("{0,-20}",tipo)}|{string.Format("{0,-40}", nombre)}|{string.Format("{0,-10}", añoLanzamiento)}|{string.Format("{0,-20}", genero)}";
        }

        public string ToNullFormat()
        {
            return $"                    |                                        |          |                    ";
        }
        public string type { get; set; }
        public string name { get; set; }
        public string year { get; set; }
        public string genre { get; set; }
    }
}