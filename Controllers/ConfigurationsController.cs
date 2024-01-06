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
    public class ConfigurationsController : Controller
    {
        private readonly CRUDContext _context;

        public ConfigurationsController(CRUDContext context)
        {
            _context = context;
        }

        // GET: Configurations
        public async Task<IActionResult> Index()
        {
              return _context.Configurations != null ? 
                          View(await _context.Configurations.ToListAsync()) :
                          Problem("Entity set 'CRUDContext.Configurations'  is null.");
        }

        // GET: Configurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Configurations == null)
            {
                return NotFound();
            }

            var configuration = await _context.Configurations
                .FirstOrDefaultAsync(m => m.ConfigId == id);
            if (configuration == null)
            {
                return NotFound();
            }

            return View(configuration);
        }

        // GET: Configurations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Configurations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConfigId,ConfigName,ConfigValue")] Configuration configuration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configuration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(configuration);
        }

        // GET: Configurations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Configurations == null)
            {
                return NotFound();
            }

            var configuration = await _context.Configurations.FindAsync(id);
            if (configuration == null)
            {
                return NotFound();
            }
            return View(configuration);
        }

        // POST: Configurations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConfigId,ConfigName,ConfigValue")] Configuration configuration)
        {
            if (id != configuration.ConfigId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigurationExists(configuration.ConfigId))
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
            return View(configuration);
        }

        // GET: Configurations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Configurations == null)
            {
                return NotFound();
            }

            var configuration = await _context.Configurations
                .FirstOrDefaultAsync(m => m.ConfigId == id);
            if (configuration == null)
            {
                return NotFound();
            }

            return View(configuration);
        }

        // POST: Configurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Configurations == null)
            {
                return Problem("Entity set 'CRUDContext.Configurations'  is null.");
            }
            var configuration = await _context.Configurations.FindAsync(id);
            if (configuration != null)
            {
                _context.Configurations.Remove(configuration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfigurationExists(int id)
        {
          return (_context.Configurations?.Any(e => e.ConfigId == id)).GetValueOrDefault();
        }
    }
}
