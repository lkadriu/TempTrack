using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TempTrackApp.Models;

namespace TempTrackApp.Controllers
{
    [Authorize]
    public class KlientisController : Controller
    {
        private readonly CRUDContext _context;

        public KlientisController(CRUDContext context)
        {
            _context = context;
        }

        // GET: Klientis
        public async Task<IActionResult> Index()
        {
              return _context.Klientis != null ? 
                          View(await _context.Klientis.ToListAsync()) :
                          Problem("Entity set 'CRUDContext.Klientis'  is null.");
        }

        // GET: Klientis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Klientis == null)
            {
                return NotFound();
            }

            var klienti = await _context.Klientis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klienti == null)
            {
                return NotFound();
            }

            return View(klienti);
        }

        // GET: Klientis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klientis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientCode,Name,Email")] Klienti klienti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klienti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klienti);
        }

        // GET: Klientis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Klientis == null)
            {
                return NotFound();
            }

            var klienti = await _context.Klientis.FindAsync(id);
            if (klienti == null)
            {
                return NotFound();
            }
            return View(klienti);
        }

        // POST: Klientis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientCode,Name,Email")] Klienti klienti)
        {
            if (id != klienti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klienti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientiExists(klienti.Id))
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
            return View(klienti);
        }

        // GET: Klientis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Klientis == null)
            {
                return NotFound();
            }

            var klienti = await _context.Klientis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klienti == null)
            {
                return NotFound();
            }

            return View(klienti);
        }

        // POST: Klientis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Klientis == null)
            {
                return Problem("Entity set 'CRUDContext.Klientis'  is null.");
            }
            var klienti = await _context.Klientis.FindAsync(id);
            if (klienti != null)
            {
                _context.Klientis.Remove(klienti);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlientiExists(int id)
        {
          return (_context.Klientis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
