using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using shoopsupermarket.Data;

namespace shoopsupermarket.Models
{
    public class Orden
    {
        public int ID { get; set; }
        public int CLI_ID { get; set; }
        private DateTime _FECH_ORD { get; set; }
        public string ESTADO { get; set; }
        public string NOM_CLI { get; set; }
        public string CLIENTE { get; set; }
        public decimal LONG { get; set; }
        public decimal LAT { get; set; }
        public string COMENT { get; set; }

        [Display(Name = "Fecha de orden")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd mm yyy hh:mm:ss}")]
        public DateTime FECH_ORD { 
            get{ return _FECH_ORD; } 
            set{ _FECH_ORD = DateTime.Now; }
        }
    }
}