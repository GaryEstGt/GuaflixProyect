using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biblioteca;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Guaflix.Models
{
    public class Pelicula : IFixedSizeText
    {
        [Display(Name = "Tipo")]
        public string type { get; set; }
        [Display(Name = "Nombre")]
        public string name { get; set; }
        [Display(Name = "Año de lanzamiento")]
        public string year { get; set; }
        [Display(Name = "Genero")]
        public string genre { get; set; }

        public static Func<string, Pelicula> ConvertToPelicula = ConvertirPelicula;
        public static Func<string> ToNullPelicula = ToNullFormat;

        public Pelicula(string Tipo, string Nombre, string Año, string Genero)
        {
            type = Tipo;
            name = Nombre;
            year = Año;
            genre = Genero;            
        }
        public int FixedSizeText { get {return 93; } set {; } }
        public static int FixedSize { get { return 93; }}
        public string ToFixedSizeString()
        {
            return $"{string.Format("{0,-20}", type)}/{string.Format("{0,-40}", name)}/{string.Format("{0,-10}", year)}/{string.Format("{0,-20}", genre)}";
        }

        public static string ToNullFormat()
        {
            return $"                    /                                        /          /                    ";
        }

        public static Pelicula ConvertirPelicula(string texto)
        {
            bool vacio = true;
            string[] datos = texto.Split('/');
            for (int i = 0; i < datos.Length; i++)
            {
                if (datos[i].Trim() != "")
                {
                    vacio = false;
                }
            }

            if (!vacio)
            {
                Pelicula pelicula = new Pelicula(datos[0].Trim(), datos[1].Trim(), datos[2].Trim(), datos[3].Trim());
                return pelicula;
            }
            else
            {
                return null;
            }
        }

        public static Comparison<Pelicula> CompareByName = delegate (Pelicula p1, Pelicula p2)
        {
            return p1.name.CompareTo(p2.name);
        };

        public static Comparison<Pelicula> CompareByGenre = delegate (Pelicula p1, Pelicula p2)
        {
            return p1.genre.CompareTo(p2.genre);
        };

        public static Comparison<Pelicula> CompareByYear = delegate (Pelicula p1, Pelicula p2)
        {
            return p1.year.CompareTo(p2.year);
        };
        private readonly List<Pelicula> pelicula;
        
        public int SelectedFlavorId { get; set; }

        public IEnumerable<SelectListItem> FlavorItems
        {
            get { return new SelectList(pelicula, "type", "Name"); }
        }
    }
}