using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using shoopsupermarket.Data;

namespace shoopsupermarket.Models
{
    public class SliderConfiguracion
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "¡Este campo es requerido!")]
        [Display(Name = "Direccion de la imagen")]
        [DataType(DataType.Url)]
        public string CONT { get; set; }

        public static List<SliderConfiguracion> Get(){
            using(var db = new ApplicationDbContext()){
                return db.SliderConfiguracion.ToList();
            }
        }
    }
}