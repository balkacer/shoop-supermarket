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

namespace shoopsupermarket.Controllers
{
    //[Authorize(Roles="Admin")]
    public class ArticulosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articulos
        [Route("Admin/{controller}")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Articulos.Include(a => a.CAT).Include(a => a.PROV);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Articulos/Details/5
        [Route("Admin/{controller}/{action}/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.CAT)
                .Include(a => a.PROV)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: Articulos/Create
        [Route("Admin/{controller}/{action}")]
        public IActionResult Create()
        {
            ViewData["CAT_ID"] = new SelectList(_context.Categorias, "ID", "CAT");
            ViewData["PROV_ID"] = new SelectList(_context.Proveedores, "ID", "NAME");
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Admin/{controller}/{action}")]
        public async Task<IActionResult> Create([Bind("ID,DESC,PRE_VENT,STOCK,PRE_COMP,PROV_ID,CAT_ID,IMG")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                articulo.DESC = articulo.DESC.ToUpper();
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CAT_ID"] = new SelectList(_context.Categorias, "ID", "CAT", articulo.CAT_ID);
            ViewData["PROV_ID"] = new SelectList(_context.Proveedores, "ID", "NAME", articulo.PROV_ID);
            return View(articulo);
        }

        // GET: Articulos/Edit/5
        [Route("Admin/{controller}/{action}/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            ViewData["CAT_ID"] = new SelectList(_context.Categorias, "ID", "CAT", articulo.CAT_ID);
            ViewData["PROV_ID"] = new SelectList(_context.Proveedores, "ID", "NAME", articulo.PROV_ID);
            return View(articulo);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Admin/{controller}/{action}/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DESC,PRE_VENT,STOCK,PRE_COMP,PROV_ID,CAT_ID,IMG")] Articulo articulo)
        {
            if (id != articulo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    articulo.DESC = articulo.DESC.ToUpper();
                    _context.Update(articulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticuloExists(articulo.ID))
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
            ViewData["CAT_ID"] = new SelectList(_context.Categorias, "ID", "CAT", articulo.CAT_ID);
            ViewData["PROV_ID"] = new SelectList(_context.Proveedores, "ID", "NAME", articulo.PROV_ID);
            return View(articulo);
        }

        // GET: Articulos/Delete/5
        [Route("Admin/{controller}/{action}/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.CAT)
                .Include(a => a.PROV)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Admin/{controller}/{action}/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.ID == id);
        }
    }
}
