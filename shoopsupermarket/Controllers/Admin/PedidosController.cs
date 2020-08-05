using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shoopsupermarket.Data;
using shoopsupermarket.Models;

namespace shoopsupermarket.Controllers.Admin
{
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        [Route("Admin/{controller}")]
        public IActionResult Index()
        {
            return View(new Pedido());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Admin/{controller}/{action}/{id}")]
        public async Task<IActionResult> Index(int id, [Bind("ORD_ID,ART_ID,DESC,CANT,PRE_UNIT,IMG,ID,CLI_ID,USER,EMAIL,ADDR,LONG,LAT,COMENT,EST_ID,ESTADOID,TOTAL,FECH_ORD")] Pedido pedido)
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
            return View(pedido);
        }

        // GET: Map
        [Route("Admin/{controller}")]
        public IActionResult Map()
        {
            return View(new Pedido());
        }

        // GET: Map?est=Completado
        [HttpGet]
        [Route("Admin/{controller}")]
        public async Task<IActionResult> Map(string est)
        {
            var pedidos = from s in _context.Pedidos select s;
            var estados = from s in _context.Estados select s;

            int estId = 0;

            foreach (var item in estados)
            {
                if (item.ESTADO == est)
                {
                    estId = item.ID;
                }
            }

            if (!String.IsNullOrEmpty(est))
            {
                pedidos = pedidos.Where(p => p.ID == estId);
            }

            return View(await pedidos.AsNoTracking().ToListAsync());
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.ID == id);
        }
    }
}