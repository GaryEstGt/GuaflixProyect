using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Guaflix.Models
{
    public class Usuario
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

    }
}