using System.ComponentModel.DataAnnotations;
 
namespace shoopsupermarket.Models
{
    public class Cart
    {
        [Key]
        public int      RecordId    { get; set; }
        public string   CartId      { get; set; }
        public int      ArticuloId     { get; set; }
        public int      Count       { get; set; }
        public System.DateTime DateCreated { get; set; }
        private Articulo _Articulo;
        public Articulo Articulo
        {
            get 
            { 
                return _Articulo = new Articulo().GetById(ArticuloId);
            }
            set 
            { 
                _Articulo = value;
            }
        }
    }
}