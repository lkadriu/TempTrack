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
    public class ForecastsController : Controller
    {
        private readonly CRUDContext _context;

        public ForecastsController(CRUDContext context)
        {
            _context = context;
        }

        // GET: Forecasts
        public async Task<IActionResult> Index()
        {
              return _context.Forecasts != null ? 
                          View(await _context.Forecasts.ToListAsync()) :
                          Problem("Entity set 'CRUDContext.Forecasts'  is null.");
        }

        // GET: Forecasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Forecasts == null)
            {
                return NotFound();
            }

            var forecast = await _context.Forecasts
                .FirstOrDefaultAsync(m => m.ForecastId == id);
            if (forecast == null)
            {
                return NotFound();
            }

            return View(forecast);
        }

        // GET: Forecasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forecasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ForecastId,City,Temperature,ForecastDate")] Forecast forecast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forecast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forecast);
        }

        // GET: Forecasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Forecasts == null)
            {
                return NotFound();
            }

            var forecast = await _context.Forecasts.FindAsync(id);
            if (forecast == null)
            {
                return NotFound();
            }
            return View(forecast);
        }

        // POST: Forecasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ForecastId,City,Temperature,ForecastDate")] Forecast forecast)
        {
            if (id != forecast.ForecastId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forecast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForecastExists(forecast.ForecastId))
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
            return View(forecast);
        }

        // GET: Forecasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Forecasts == null)
            {
                return NotFound();
            }

            var forecast = await _context.Forecasts
                .FirstOrDefaultAsync(m => m.ForecastId == id);
            if (forecast == null)
            {
                return NotFound();
            }

            return View(forecast);
        }

        // POST: Forecasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Forecasts == null)
            {
                return Problem("Entity set 'CRUDContext.Forecasts'  is null.");
            }
            var forecast = await _context.Forecasts.FindAsync(id);
            if (forecast != null)
            {
                _context.Forecasts.Remove(forecast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForecastExists(int id)
        {
          return (_context.Forecasts?.Any(e => e.ForecastId == id)).GetValueOrDefault();
        }
    }
}
