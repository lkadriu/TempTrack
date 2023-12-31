using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TempTrackApp.Models;

namespace TempTrackApp.Controllers
{
    public class KategoriteEmotitsController : Controller
    {
        private readonly CRUDContext _context;

        public KategoriteEmotitsController(CRUDContext context)
        {
            _context = context;
        }

        // GET: KategoriteEmotits
        public async Task<IActionResult> Index()
        {
              return _context.KategoriteEmotits != null ? 
                          View(await _context.KategoriteEmotits.ToListAsync()) :
                          Problem("Entity set 'CRUDContext.KategoriteEmotits'  is null.");
        }

        // GET: KategoriteEmotits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KategoriteEmotits == null)
            {
                return NotFound();
            }

            var kategoriteEmotit = await _context.KategoriteEmotits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategoriteEmotit == null)
            {
                return NotFound();
            }

            return View(kategoriteEmotit);
        }

        // GET: KategoriteEmotits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KategoriteEmotits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Emri,Pershkrimi,TemperaturaMin,TemperaturaMax")] KategoriteEmotit kategoriteEmotit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategoriteEmotit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategoriteEmotit);
        }

        // GET: KategoriteEmotits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KategoriteEmotits == null)
            {
                return NotFound();
            }

            var kategoriteEmotit = await _context.KategoriteEmotits.FindAsync(id);
            if (kategoriteEmotit == null)
            {
                return NotFound();
            }
            return View(kategoriteEmotit);
        }

        // POST: KategoriteEmotits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Emri,Pershkrimi,TemperaturaMin,TemperaturaMax")] KategoriteEmotit kategoriteEmotit)
        {
            if (id != kategoriteEmotit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategoriteEmotit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriteEmotitExists(kategoriteEmotit.Id))
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
            return View(kategoriteEmotit);
        }

        // GET: KategoriteEmotits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KategoriteEmotits == null)
            {
                return NotFound();
            }

            var kategoriteEmotit = await _context.KategoriteEmotits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategoriteEmotit == null)
            {
                return NotFound();
            }

            return View(kategoriteEmotit);
        }

        // POST: KategoriteEmotits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KategoriteEmotits == null)
            {
                return Problem("Entity set 'CRUDContext.KategoriteEmotits'  is null.");
            }
            var kategoriteEmotit = await _context.KategoriteEmotits.FindAsync(id);
            if (kategoriteEmotit != null)
            {
                _context.KategoriteEmotits.Remove(kategoriteEmotit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriteEmotitExists(int id)
        {
          return (_context.KategoriteEmotits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
