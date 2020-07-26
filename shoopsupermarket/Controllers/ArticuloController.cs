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
    public class ArticuloController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticuloController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articulo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Articulos.Include(a => a.PROV);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Articulo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.PROV)
                .FirstOrDefaultAsync(m => m.ARTI_ID == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: Articulo/Create
        public IActionResult Create()
        {
            ViewData["PROVRefId"] = new SelectList(_context.Proveedores, "PROV_ID", "NAME");
            return View();
        }

        // POST: Articulo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ARTI_ID,DESC,PRE_VENT,STOCK,PRE_COMP,ImgUrl,PROVRefId")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                articulo.DESC = articulo.DESC.ToUpper();
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PROVRefId"] = new SelectList(_context.Proveedores, "PROV_ID", "NAME", articulo.PROVRefId);
            return View(articulo);
        }

        // GET: Articulo/Edit/5
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
            ViewData["PROVRefId"] = new SelectList(_context.Proveedores, "PROV_ID", "NAME", articulo.PROVRefId);
            return View(articulo);
        }

        // POST: Articulo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ARTI_ID,DESC,PRE_VENT,STOCK,PRE_COMP,ImgUrl,PROVRefId")] Articulo articulo)
        {
            if (id != articulo.ARTI_ID)
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
                    if (!ArticuloExists(articulo.ARTI_ID))
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
            ViewData["PROVRefId"] = new SelectList(_context.Proveedores, "PROV_ID", "NAME", articulo.PROVRefId);
            return View(articulo);
        }

        // GET: Articulo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.PROV)
                .FirstOrDefaultAsync(m => m.ARTI_ID == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST: Articulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.ARTI_ID == id);
        }
    }
}
