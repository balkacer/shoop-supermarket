using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        [DataType(DataType.Currency, ErrorMessage = "¡Introduce un valor de moneda!")]
        [Display(Name = "Precio de Venta")]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        public double PRE_VENT { get; set;}


        [Display(Name = "Stock")]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        public int STOCK { get; set;}


        [Display(Name = "Precio de Compra")]
        [DataType(DataType.Currency, ErrorMessage = "¡Introduce un valor de moneda!")]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        public double PRE_COMP { get; set;}

        
        [Display(Name = "Proveedor")]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        public int PROVRefId { get; set;}
        [Display(Name = "Proveedor")]
        public Proveedor PROV { get; set; }
    }
}