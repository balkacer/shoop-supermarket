using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using shoopsupermarket.Data;

namespace shoopsupermarket.Models
{
    public class ArticulosOrden
    {
        [Key, Column(Order = 0)]
        public int ORD_ID { get; set; }
        [Key, Column(Order = 1)]
        public int ART_ID { get; set; }
        private string _DESC;
        private int _CANT;
        private double _PRE_UNIT;
        private string _IMG;                
        
        public virtual Orden Orden { get; set; }
        public virtual Articulo Articulo { get; set; }

        [Display(Name = "Descripción")]
        public string DESC
        {
            get { return _DESC = Articulo.GetById(ART_ID).DESC; }
            set { _DESC = value; }
        }   

        [Display(Name = "Cantidad")]
        public int CANT { 
            get{ return _CANT; }
            set
            {
                _CANT = value;
                Articulo.UpdateStock(ART_ID, _CANT);
            } 
        }

        [Display(Name = "Precio")]
        public double PRE_UNIT
        {
            get { return _PRE_UNIT = Articulo.GetById(ART_ID).PRE_VENT; }
            set { _PRE_UNIT = value; }
        }

        [Display(Name = "Subtotal")]
        public double SUB_TOTAL 
        { 
            get { return PRE_UNIT * CANT; }
        }

        [Display(Name = "Dirección de Imagen")]
        public string IMG
        {
            get { return _IMG = Articulo.GetById(ART_ID).IMG; }
            set { _IMG = value; }
        }

        public static List<ArticulosOrden> Get(){
            using(var db = new ApplicationDbContext()){
                return db.ArticulosOrdenes.ToList();
            }
        }
    }
}