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
        public int ID { get; set; }
        public int ORD_ID { get; set; }
        public int ART_ID { get; set; }
        private decimal _PRE_UNIT;        
        public virtual Pedido Pedido { get; set; }
        public virtual Articulo Articulo { get; set; }
        public int CANT { get;set; }
        public decimal PRE_UNIT{ get; set; }
        public decimal SUB_TOTAL 
        { 
            get { return PRE_UNIT * CANT; }
        }
        public static List<DetallePedido> Get(){
            using(var db = new ApplicationDbContext()){
                return db.DetallePedidos.ToList();
            }
        }
    }
}