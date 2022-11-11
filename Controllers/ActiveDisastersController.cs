using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_2.Data;
using Task_2.Models;

namespace Task_2.Controllers
{
    public class ActiveDisastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActiveDisastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActiveDisasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActiveDisasters.ToListAsync());
        }

        // GET: ActiveDisasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeDisasters = await _context.ActiveDisasters
                .FirstOrDefaultAsync(m => m.id == id);
            if (activeDisasters == null)
            {
                return NotFound();
            }

            return View(activeDisasters);
        }

        // GET: ActiveDisasters/Create
        public IActionResult Create()
        {
            var disaster = new SelectList(_context.DisasterType.OrderBy(l => l.disasterType)
             .ToDictionary(us => us.Id, us => us.disasterType), "Value", "Value");
            ViewBag.disastertypes = disaster;
            return View();
        }

        // POST: ActiveDisasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DisasterType")] ActiveDisasters activeDisasters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activeDisasters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activeDisasters);
        }

        // GET: ActiveDisasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var disaster = new SelectList(_context.DisasterType.OrderBy(l => l.disasterType)
           .ToDictionary(us => us.Id, us => us.disasterType), "Value", "Value");
            ViewBag.disastertypes = disaster;

            if (id == null)
            {
                return NotFound();
            }

            var activeDisasters = await _context.ActiveDisasters.FindAsync(id);
            if (activeDisasters == null)
            {
                return NotFound();
            }
            return View(activeDisasters);
        }

        // POST: ActiveDisasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DisasterType")] ActiveDisasters activeDisasters)
        {
            var disaster = new SelectList(_context.DisasterType.OrderBy(l => l.disasterType)
             .ToDictionary(us => us.Id, us => us.disasterType), "Value", "Value");
            ViewBag.disastertypes = disaster;

            if (id != activeDisasters.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activeDisasters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiveDisastersExists(activeDisasters.id))
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
            return View(activeDisasters);
        }

        // GET: ActiveDisasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeDisasters = await _context.ActiveDisasters
                .FirstOrDefaultAsync(m => m.id == id);
            if (activeDisasters == null)
            {
                return NotFound();
            }

            return View(activeDisasters);
        }

        // POST: ActiveDisasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activeDisasters = await _context.ActiveDisasters.FindAsync(id);
            _context.ActiveDisasters.Remove(activeDisasters);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiveDisastersExists(int id)
        {
            return _context.ActiveDisasters.Any(e => e.id == id);
        }
    }
}
