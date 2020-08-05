using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shoopsupermarket.Data;
using shoopsupermarket.Models;

namespace shoopsupermarket.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Checkout
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pedidos.Include(p => p.Estado);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Checkout/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Estado)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Checkout/Create
        public IActionResult Create()
        {
            ViewData["EstadoId"] = new SelectList(_context.Estados, "ID", "NOMBRE");
            return View();
        }

        // POST: Checkout/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Username,FirstName,LastName,Address,City,State,Longitud,Latitud,Country,Phone,Total,EstadoId,pedidoDate")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pedido.Username = User.Identity.Name;
                    pedido.OrderDate = DateTime.Now;
        
                    //Save pedido
                    //Process the pedido
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(pedido);
                }
                catch
                {
                    //Invalid - redisplay with errors
                    return View(pedido);
                }

                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "ID", "NOMBRE", pedido.EstadoId);
            return View(pedido);
        }

        // GET: Checkout/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "ID", "NOMBRE", pedido.EstadoId);
            return View(pedido);
        }

        // POST: Checkout/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Username,FirstName,LastName,Address,City,State,Longitud,Latitud,Country,Phone,Total,EstadoId,pedidoDate")] Pedido pedido)
        {
            if (id != pedido.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "ID", "NOMBRE", pedido.EstadoId);
            return View(pedido);
        }

        // GET: Checkout/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Estado)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Checkout/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.ID == id);
        }
    }
}
