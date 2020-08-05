using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using shoopsupermarket.Data;

namespace shoopsupermarket.Models
{
    public class Estado
    {
        public int ID { get; set; }

        [Display(Name = "Estado")]
        [Required]
        public string NOMBRE { get; set; }

        [ForeignKey("EstadoId")]
        public ICollection<Pedido> Pedido { get; set; }

        public static List<Estado> Get(){
            using(var db = new ApplicationDbContext()){
                return db.Estados.ToList();
            }
        }
    }
}