using System.Linq;
using shoopsupermarket.Data;
using shoopsupermarket.Models;
using shoopsupermarket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace shoopsupermarket.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        //
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
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
 
            // Get the name of the album to display confirmation
            string art = context.Carts
                .Single(item => item.RecordId == id).Articulo.DESC;
 
            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);
 
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = System.Web.HttpUtility.HtmlEncode(art) +
                    " se eliminió del carrito.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
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