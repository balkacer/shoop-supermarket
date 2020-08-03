using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using shoopsupermarket.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace shoopsupermarket.Models
{
    public class Pedido
    {
        public int ID { get; set; }
        public string CLI_ID { get; set; }
        public string USER { get; set; }
        public string EMAIL { get; set; }
        private DateTime _FECH_ORD;
        private DateTime _FECH_ENV;
        public string ADDR { get; set; }
        public float LONG { get; set; }
        public float LAT { get; set; }
        public string COMENT { get; set; }
        private double _TOTAL;
        [Display(Name = "Estado")]
        [Required (ErrorMessage = "¡Este campo es requerido!")]
        public int EST_ID { get; set; }


        
        [Display(Name = "Estado")]
        public virtual Estado ESTADO { get; set; }
        public List<DetallePedido> Articulos { get; set; }
        

        public double TOTAL
        {
            get { return _TOTAL = SubtotalSum(); }
            set { _TOTAL = value; }
        }
        [Display(Name = "Fecha de orden")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd mm yyy hh:mm:ss}")]
        public DateTime FECH_ORD { 
            get{ return _FECH_ORD; } 
            set{ _FECH_ORD = DateTime.Now; }
        }


        public double SubtotalSum(){
            using(var db = new ApplicationDbContext()){
                var pr = db.DetallePedidos.Where(dp => dp.ORD_ID == ID).ToList();
                double totalSuma = 0;
                foreach (var item in pr)
                {
                    totalSuma += item.SUB_TOTAL;
                }
                return totalSuma;
            }            
        }
    }
}