using System;

namespace shoopsupermarket.Models
{
    public class Articulo
    {
        public int ARTI_ID { get; set;}
        public string DESC { get; set;}
        public double PRE_VENT { get; set;}
        public int STOCK { get; set;}
        public double PRE_COMP { get; set;}
        public int PROV_ID { get; set;}
    }
}