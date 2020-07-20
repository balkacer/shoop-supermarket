using System.ComponentModel.DataAnnotations;

namespace shoopsupermarket.Models
{
    public class Usuario
    {
        [Key]
        public int USER_ID { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "Nombre")]
        public string NOMBRE { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "Apellido")]
        public string APELLIDO { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El {0} no es valido")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "La {0} es requerida")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "El minimo de caracteres son 8")]
        public string PASSWORD { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("PASSWORD", ErrorMessage = "Las contraseñas no coinsiden")]
        public string CONFIRM_PASS { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string TELEFONO { get; set; }

    }
}