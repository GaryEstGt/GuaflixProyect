using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Biblioteca;

namespace Guaflix.Models
{
    public class Usuario : IFixedSizeText
    {
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Required]
        [Display(Name = "Edad")]
        public int edad { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string username { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        [Display(Name = "Confirmar Contraseña")]
        public string Cpassword { get; set; }
        public ArbolB<Pelicula> WatchList;
        public static Func<string, Usuario> ConvertToUsuario = ConvertirUsuario;
        public static Func<string> ToNullUsuario = ToNullFormat;

        public int FixedSizeText { get { return 116; } set {; } }
        public static int FixedSize { get {return 116; }}
        public Usuario(string Nombre, string Apellido, int Edad, string User, string Pass, string CPass)
        {
            nombre = Nombre;
            apellido = Apellido;
            edad = Edad;
            username = User;
            password = Pass;
            Cpassword = CPass;            
        }
        public string ToFixedSizeString()
        {
            return $"{string.Format("{0,-20}", nombre)}/{string.Format("{0,-20}", apellido)}/{edad.ToString("00000000000;-0000000000")}/{string.Format("{0,-20}", username)}/{string.Format("{0,-20}", password)}/{string.Format("{0,-20}", Cpassword)}";
        }

        public static string ToNullFormat()
        {
            return $"                    /                    /           /                    /                    /                    ";
        }

        public static Usuario ConvertirUsuario(string texto)
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
                Usuario usuario = new Usuario(datos[0].Trim(), datos[1].Trim(), int.Parse(datos[2].Trim()), datos[3].Trim(), datos[4].Trim(), datos[5].Trim());
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public static Comparison<Usuario> CompareByName = delegate (Usuario p1, Usuario p2)
        {
            return p1.nombre.CompareTo(p2.nombre);
        };
        public static Comparison<Usuario> CompareByUserName = delegate (Usuario p1, Usuario p2)
        {
            return p1.username.CompareTo(p2.username);
        };
        public static Comparison<Usuario> CompareByPassword = delegate (Usuario p1, Usuario p2)
        {
            return p1.password.CompareTo(p2.password);
        };
    }
}