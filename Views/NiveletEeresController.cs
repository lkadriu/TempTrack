using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TempTrackApp.Models;

namespace TempTrackApp.Views
{
    public class NiveletEeresController : Controller
    {
        private readonly CRUDContext _context;

        public NiveletEeresController(CRUDContext context)
        {
            _context = context;
        }

        // GET: NiveletEeres
        public async Task<IActionResult> Index()
        {
              return _context.NiveletEeres != null ? 
                          View(await _context.NiveletEeres.ToListAsync()) :
                          Problem("Entity set 'CRUDContext.NiveletEeres'  is null.");
        }

        // GET: NiveletEeres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NiveletEeres == null)
            {
                return NotFound();
            }

            var niveletEere = await _context.NiveletEeres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (niveletEere == null)
            {
                return NotFound();
            }

            return View(niveletEere);
        }

        // GET: NiveletEeres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NiveletEeres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Emri,Pershkrimi,ShpejtesiaMin,ShpejtesiaMax")] NiveletEere niveletEere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(niveletEere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(niveletEere);
        }

        // GET: NiveletEeres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NiveletEeres == null)
            {
                return NotFound();
            }

            var niveletEere = await _context.NiveletEeres.FindAsync(id);
            if (niveletEere == null)
            {
                return NotFound();
            }
            return View(niveletEere);
        }

        // POST: NiveletEeres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Emri,Pershkrimi,ShpejtesiaMin,ShpejtesiaMax")] NiveletEere niveletEere)
        {
            if (id != niveletEere.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(niveletEere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NiveletEereExists(niveletEere.Id))
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
            return View(niveletEere);
        }

        // GET: NiveletEeres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NiveletEeres == null)
            {
                return NotFound();
            }

            var niveletEere = await _context.NiveletEeres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (niveletEere == null)
            {
                return NotFound();
            }

            return View(niveletEere);
        }

        // POST: NiveletEeres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NiveletEeres == null)
            {
                return Problem("Entity set 'CRUDContext.NiveletEeres'  is null.");
            }
            var niveletEere = await _context.NiveletEeres.FindAsync(id);
            if (niveletEere != null)
            {
                _context.NiveletEeres.Remove(niveletEere);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NiveletEereExists(int id)
        {
          return (_context.NiveletEeres?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
