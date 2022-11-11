using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_2.Data;
using Task_2.Models;

namespace Task_2.Controllers
{
    public class DisasterTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisasterTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DisasterTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DisasterType.ToListAsync());
        }

        // GET: DisasterTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterType = await _context.DisasterType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disasterType == null)
            {
                return NotFound();
            }

            return View(disasterType);
        }

        // GET: DisasterTypes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisasterTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("Id,disasterType,startDate,endDate,description,location,aidRequired")] DisasterType DType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(DType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(DType);
        }

        // GET: DisasterTypes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterType = await _context.DisasterType.FindAsync(id);
            if (disasterType == null)
            {
                return NotFound();
            }
            return View(disasterType);
        }

        // POST: DisasterTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Edit(int id, [Bind("Id,disasterType,startDate,endDate,description,location,aidRequired")] DisasterType disasterType_1)
        {
            if (id != disasterType_1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disasterType_1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisasterTypeExists(disasterType_1.Id))
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
            return View(disasterType_1);
        }

        // GET: DisasterTypes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterType = await _context.DisasterType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disasterType == null)
            {
                return NotFound();
            }

            return View(disasterType);
        }

        // POST: DisasterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disasterType = await _context.DisasterType.FindAsync(id);
            _context.DisasterType.Remove(disasterType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisasterTypeExists(int id)
        {
            return _context.DisasterType.Any(e => e.Id == id);
        }
    }
}
