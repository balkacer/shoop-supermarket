using System.Linq;
using shoopsupermarket.Data;
using shoopsupermarket.Models;
using shoopsupermarket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace shoopsupermarket.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext context;
        
        public ShoppingCartController (ApplicationDbContext _context)
        {
            context = _context;
        }
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
 
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var articuloAgregado = context.Articulos
                .Single(articulo => articulo.ID == id);
 
            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
 
            cart.AddToCart(articuloAgregado);
            Console.WriteLine(articuloAgregado.DESC);
 
            // Go back to the main store page for more shopping
            return RedirectToAction("Index", "Home");
        }
        //
        // POST: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var cartItem = await context.Carts.FindAsync(id);
            context.Carts.Remove(cartItem);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        // GET: /ShoppingCart/CartSummary
        // [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
 
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}