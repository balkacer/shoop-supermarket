using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using shoopsupermarket.Data;

namespace shoopsupermarket.Models
{
    public class Categoria
    {
        public int ID { get; set; }

        [Display(Name = "Categoria")]
        public string CAT { get; set; }

        [ForeignKey("CAT_ID")]
        public ICollection<Articulo> Articulos { get; set; }

        public static List<Categoria> Get(){
            using(var db = new ApplicationDbContext()){
                return db.Categorias.ToList();
            }
        }
    }
}