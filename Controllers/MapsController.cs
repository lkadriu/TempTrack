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
    public class MapsController : Controller
    {
        private readonly CRUDContext _context;

        public MapsController(CRUDContext context)
        {
            _context = context;
        }

        // GET: Maps
        public async Task<IActionResult> Index()
        {
              return _context.Maps != null ? 
                          View(await _context.Maps.ToListAsync()) :
                          Problem("Entity set 'CRUDContext.Maps'  is null.");
        }

        // GET: Maps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Maps == null)
            {
                return NotFound();
            }

            var map = await _context.Maps
                .FirstOrDefaultAsync(m => m.MapId == id);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }

        // GET: Maps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MapId,Name,Latitude,Longitude")] Map map)
        {
            if (ModelState.IsValid)
            {
                _context.Add(map);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(map);
        }

        // GET: Maps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Maps == null)
            {
                return NotFound();
            }

            var map = await _context.Maps.FindAsync(id);
            if (map == null)
            {
                return NotFound();
            }
            return View(map);
        }

        // POST: Maps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MapId,Name,Latitude,Longitude")] Map map)
        {
            if (id != map.MapId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(map);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapExists(map.MapId))
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
            return View(map);
        }

        // GET: Maps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Maps == null)
            {
                return NotFound();
            }

            var map = await _context.Maps
                .FirstOrDefaultAsync(m => m.MapId == id);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }

        // POST: Maps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Maps == null)
            {
                return Problem("Entity set 'CRUDContext.Maps'  is null.");
            }
            var map = await _context.Maps.FindAsync(id);
            if (map != null)
            {
                _context.Maps.Remove(map);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapExists(int id)
        {
          return (_context.Maps?.Any(e => e.MapId == id)).GetValueOrDefault();
        }
    }
}
