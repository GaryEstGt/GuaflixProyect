using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biblioteca;

namespace Guaflix.Models
{
    public class Pelicula : IFixedSizeText
    {
        public string type { get; set; }
        public string name { get; set; }
        public string year { get; set; }
        public string genre { get; set; }
        public Pelicula(string Tipo, string Nombre, string Año, string Genero)
        {
            type = Tipo;
            name = Nombre;
            year = Año;
            genre = Genero;
            FixedSize = 93;
            FixedSizeText = FixedSize;
        }
        public int FixedSizeText { get; set; }
        public static int FixedSize { get; set; }
        public string ToFixedSizeString()
        {
            return $"{string.Format("{0,-20}",type)}/{string.Format("{0,-40}", name)}/{string.Format("{0,-10}", year)}/{string.Format("{0,-20}", genre)}";
        }

        public string ToNullFormat()
        {
            return $"                    /                                        /          /                    ";
        }        
    }
}