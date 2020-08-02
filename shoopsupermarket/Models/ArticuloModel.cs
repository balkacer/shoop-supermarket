using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using shoopsupermarket.Data;

namespace shoopsupermarket.Models
{
    public class Articulo
    {
        public int ID { get; set;}
        [MaxLength(50, ErrorMessage = "¡No más de 50  caracteres!")]
        [Display(Name = "Descripción")]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        public string DESC { get; set;}
        [DataType(DataType.Currency, ErrorMessage = "¡Introduce un valor de moneda!")]
        [Display(Name = "Precio de Venta")]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        public double PRE_VENT { get; set;}
        [Display(Name = "Stock")]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        private int _STOCK;
        public int STOCK
        {
            get { return _STOCK;}
            set { _STOCK = value;}
        }
        [Display(Name = "Precio de Compra")]
        [DataType(DataType.Currency, ErrorMessage = "¡Introduce un valor de moneda!")]
        [Required (ErrorMessage = "¡Este campo es requerido")]
        public double PRE_COMP { get; set;}
        [Display(Name = "Proveedor")]
        [Required (ErrorMessage = "¡Este campo es requerido!")]
        public int PROV_ID { get; set;}
        [Display(Name = "Proveedor")]
        public Proveedor PROV { get; set; }
        [Display(Name = "Categoria")]
        [Required (ErrorMessage = "¡Este campo es requerido!")]
        public int CAT_ID { get; set;}
        [Display(Name = "Categoria")]
        public Categoria CAT { get; set; }
        [Required(ErrorMessage = "¡Este campo es requerido!")]
        [Display(Name = "Direccion de la imagen")]
        [DataType(DataType.Url)]
        public string IMG { get; set; }
        public List<Articulo> Get(){
            using(var db = new ApplicationDbContext()){
                return db.Articulos.ToList();
            }
        }

        public Articulo GetById(int id){
            using(var db = new ApplicationDbContext()){
                return db.Articulos.Find(id);
            }
        }

        public Articulo UpdateStock(int id, int cant){
            using(var db = new ApplicationDbContext()){
                Articulo art = db.Articulos.Find(id);
                art.STOCK -= cant;
                db.Articulos.Update(art);
                return db.Articulos.Find(id);
            }
        }
    }
}