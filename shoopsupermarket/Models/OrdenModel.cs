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
        public DateTime FECH_ORD { get; set; }
        public string ESTADO { get; set; }
        public int CLI_ID { get; set; }
        public string NOM_CLI { get; set; }
    }
}