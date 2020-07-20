using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using shoopsupermarket.Data;

namespace shoopsupermarket.Models
{
    public class Proveedor
    {
        //private static Regex _regex = new Regex(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

        [Key]
        public int PROV_ID { get; set; }


        [MaxLength(50, ErrorMessage = "¡No más de 50 caracteres!")]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "¡Este campo es requerido")]
        public string NAME { get; set; }

        [Required(ErrorMessage = "¡Se requiere al menos un número de teléfono!")]
        [Display(Name = "Telefono 1")]
        [MaxLength(10, ErrorMessage = "Ponga numero de telefono sin guion"), 
            MinLength(10, ErrorMessage = "Ponga numero de telefono sin guion")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "¡Número de teléfono no valido!")]
        public string PHONE1 { get; set; }

        [Display(Name = "Telefono 2")]
        [MaxLength(10, ErrorMessage = "Ponga numero de telefono sin guion"), 
            MinLength(10, ErrorMessage = "Ponga numero de telefono sin guion")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "¡Número de teléfono no valido!")]
        public string PHONE2 { get; set; }

        [ForeignKey("PROVRefId")]
        public ICollection<Articulo> Articulos { get; set; }

        public List<Proveedor> Get(){
            using(var db = new ApplicationDbContext()){
                return db.Proveedores.ToList();
            }
        }
    }
}