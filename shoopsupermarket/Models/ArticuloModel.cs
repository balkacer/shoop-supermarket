using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace shoopsupermarket.Models
{
    public class Articulo
    {
        [Key]
        public int ARTI_ID { get; set;}


        [MaxLength(50, ErrorMessage = "¡No más de 50 caracteres!")]
        [Display(Name = "Descripción")]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        public string DESC { get; set;}


        [DataType(DataType.Currency)]
        [Display(Name = "Precio de Venta")]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        public double PRE_VENT { get; set;}


        [Display(Name = "Stock")]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        public int STOCK { get; set;}


        [Display(Name = "Precio de Compra")]
        [DataType(DataType.Currency)]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        public double PRE_COMP { get; set;}

        
        [Display(Name = "Codigo de Proveedor")]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        public ICollection<Proveedor> PROV_ID { get; set;}
    }
}