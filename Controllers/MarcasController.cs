using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_practica09_EsmeraldaGarcia.Models;

namespace MVC_practica09_EsmeraldaGarcia.Controllers
{
    public class MarcasController : Controller
    {
        private readonly equiposContext _context;

        public MarcasController(equiposContext context)
        {
            _context = context;
        }

        // GET: Marcas
        public async Task<IActionResult> Index()
        {
            return View(await _context.marcas.ToListAsync());
        }

        // GET: Marcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcas = await _context.marcas
                .FirstOrDefaultAsync(m => m.marca_id == id);
            if (marcas == null)
            {
                return NotFound();
            }

            return View(marcas);
        }

        // GET: Marcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("marca_id,nombre_marca,estados")] marcas marcas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcas);
        }

        // GET: Marcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcas = await _context.marcas.FindAsync(id);
            if (marcas == null)
            {
                return NotFound();
            }
            return View(marcas);
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("marca_id,nombre_marca,estados")] marcas marcas)
        {
            if (id != marcas.marca_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!marcasExists(marcas.marca_id))
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
            return View(marcas);
        }

        // GET: Marcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcas = await _context.marcas
                .FirstOrDefaultAsync(m => m.marca_id == id);
            if (marcas == null)
            {
                return NotFound();
            }

            return View(marcas);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marcas = await _context.marcas.FindAsync(id);
            if (marcas != null)
            {
                _context.marcas.Remove(marcas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool marcasExists(int id)
        {
            return _context.marcas.Any(e => e.marca_id == id);
        }
    }
}
