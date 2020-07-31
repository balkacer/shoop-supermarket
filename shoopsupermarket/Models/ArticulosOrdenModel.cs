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
        public int ORD_ID { get; set; }
        public int ART_ID { get; set; }
        public string PRE_VENT { get; set; }
        public int CANT { get; set; }
        public string NOM_ART { get; set; }
    }
}