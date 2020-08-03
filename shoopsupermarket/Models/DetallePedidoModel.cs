using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using shoopsupermarket.Data;

namespace shoopsupermarket.Models
{
    public class DetallePedido
    {
        [ForeignKey("Pedido")]
        [Key, Column(Order = 0)]
        public int ORD_ID { get; set; }
        [ForeignKey("Articulo")]
        [Key, Column(Order = 1)]
        public int ART_ID { get; set; }
        private string _DESC;
        private double _PRE_UNIT;
        private string _IMG;     
        
        public virtual Pedido Pedido { get; set; }
        public virtual Articulo Articulo { get; set; }

        [Display(Name = "Descripción")]
        public string DESC
        {
            get { return _DESC = Articulo.DESC; }
            set { _DESC = value; }
        }   

        [Display(Name = "Cantidad")]
        public int CANT { get;set; }

        [Display(Name = "Precio")]
        public double PRE_UNIT
        {
            get { return _PRE_UNIT = Articulo.PRE_VENT; }
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
            get { return _IMG = Articulo.IMG; }
            set { _IMG = value; }
        }

        public static List<DetallePedido> Get(){
            using(var db = new ApplicationDbContext()){
                return db.DetallePedidos.ToList();
            }
        }
    }
}