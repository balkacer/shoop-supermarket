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
    public class SliderConfiguracionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SliderConfiguracionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SliderConfiguracion
        public async Task<IActionResult> Index()
        {
            return View(await _context.SliderConfiguracion.ToListAsync());
        }

        // GET: SliderConfiguracion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderConfiguracion = await _context.SliderConfiguracion
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sliderConfiguracion == null)
            {
                return NotFound();
            }

            return View(sliderConfiguracion);
        }

        // GET: SliderConfiguracion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SliderConfiguracion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CONT")] SliderConfiguracion sliderConfiguracion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sliderConfiguracion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sliderConfiguracion);
        }

        // GET: SliderConfiguracion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderConfiguracion = await _context.SliderConfiguracion.FindAsync(id);
            if (sliderConfiguracion == null)
            {
                return NotFound();
            }
            return View(sliderConfiguracion);
        }

        // POST: SliderConfiguracion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CONT")] SliderConfiguracion sliderConfiguracion)
        {
            if (id != sliderConfiguracion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sliderConfiguracion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderConfiguracionExists(sliderConfiguracion.ID))
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
            return View(sliderConfiguracion);
        }

        // GET: SliderConfiguracion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderConfiguracion = await _context.SliderConfiguracion
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sliderConfiguracion == null)
            {
                return NotFound();
            }

            return View(sliderConfiguracion);
        }

        // POST: SliderConfiguracion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sliderConfiguracion = await _context.SliderConfiguracion.FindAsync(id);
            _context.SliderConfiguracion.Remove(sliderConfiguracion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderConfiguracionExists(int id)
        {
            return _context.SliderConfiguracion.Any(e => e.ID == id);
        }
    }
}
