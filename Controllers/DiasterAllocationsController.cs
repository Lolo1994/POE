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
    public class DiasterAllocationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        
       
        public DiasterAllocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DiasterAllocations
        public async Task<IActionResult> Index()
        {
         




            return View(await _context.DiasterAllocation.ToListAsync());
        }

        


        // GET: DiasterAllocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diasterAllocation = await _context.DiasterAllocation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diasterAllocation == null)
            {
                return NotFound();
            }

            return View(diasterAllocation);
        }


        // GET: DiasterAllocations/Create
        public IActionResult Create()
        {
            var disaster = new SelectList(_context.DisasterType.OrderBy(l => l.disasterType)
              .ToDictionary(us => us.Id, us => us.disasterType), "Value", "Value");
            ViewBag.disastertypes = disaster;
            /* List<DisasterType> disaster = new List<DisasterType>();
             disaster = _context.DisasterType.ToList();
             ViewBag.disastertypes = disaster;*/

            return View();
        }

        // POST: DiasterAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,disasterType,dateAlloted,amountAllotted")] DiasterAllocation diasterAllocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diasterAllocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diasterAllocation);
        }

        // GET: DiasterAllocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var disaster = new SelectList(_context.DisasterType.OrderBy(l => l.disasterType)
             .ToDictionary(us => us.Id, us => us.disasterType), "Value", "Value");
            ViewBag.disastertypes = disaster;

            /*List<DisasterType> disaster = new List<DisasterType>();
            disaster = _context.DisasterType.ToList();
            ViewBag.disastertypes = disaster;*/

            if (id == null)
            {
                return NotFound();
            }

            var diasterAllocation = await _context.DiasterAllocation.FindAsync(id);
            if (diasterAllocation == null)
            {
                return NotFound();
            }
            return View(diasterAllocation);
        }

        // POST: DiasterAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,disasterType,dateAlloted,amountAllotted")] DiasterAllocation diasterAllocation)
        {
            if (id != diasterAllocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diasterAllocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiasterAllocationExists(diasterAllocation.Id))
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
            return View(diasterAllocation);
        }

        // GET: DiasterAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diasterAllocation = await _context.DiasterAllocation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diasterAllocation == null)
            {
                return NotFound();
            }

            return View(diasterAllocation);
        }

        // POST: DiasterAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diasterAllocation = await _context.DiasterAllocation.FindAsync(id);
            _context.DiasterAllocation.Remove(diasterAllocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiasterAllocationExists(int id)
        {
            return _context.DiasterAllocation.Any(e => e.Id == id);
        }
    }
}
