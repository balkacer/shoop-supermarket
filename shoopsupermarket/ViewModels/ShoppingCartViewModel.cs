using System.Collections.Generic;
using shoopsupermarket.Models;
 
namespace shoopsupermarket.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}