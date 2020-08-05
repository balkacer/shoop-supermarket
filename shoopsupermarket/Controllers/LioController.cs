using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shoopsupermarket.Data;
using shoopsupermarket.Models;

namespace shoopsupermarket.Controllers
{
    [Authorize]
    public class LioController : Controller
    {
        public readonly ApplicationDbContext _context;

        public LioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult AddressAndPayment()
        {
            //var applicationDbContext = _context.Pedidos.Include(a => a.EstadoId);
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public async Task<IActionResult> AddressAndPayment(IFormCollection values)
        {
            var order = new Pedido();
            await TryUpdateModelAsync(order);

            try
            {
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;
    
                //Save Order
                _context.Pedidos.Add(order);
                _context.SaveChanges();
                //Process the order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                ViewData["EstadoId"] = new SelectList(_context.Estados, "ID", "NOMBRE", order.EstadoId);
                cart.CreateOrder(order);

               
    
                return RedirectToAction("Complete",
                    new { id = order.ID });
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }

        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = _context.Pedidos.Any(
                o => o.ID == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}