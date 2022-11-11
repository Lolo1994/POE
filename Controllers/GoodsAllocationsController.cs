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
    public class GoodsAllocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsAllocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoodsAllocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.GoodsAllocation.ToListAsync());
        }

        // GET: GoodsAllocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsAllocation = await _context.GoodsAllocation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsAllocation == null)
            {
                return NotFound();
            }

            return View(goodsAllocation);
        }

        // GET: GoodsAllocations/Create
        public IActionResult Create()
        {
            var disaster = new SelectList(_context.DisasterType.OrderBy(l => l.disasterType)
            .ToDictionary(us => us.Id, us => us.disasterType), "Value", "Value");
            ViewBag.disastertypes = disaster;

            return View();
        }

        // POST: GoodsAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,goodType,dateAllocated,quantity,pricePerItem,disasterType")] GoodsAllocation goodsAllocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsAllocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goodsAllocation);
        }

        // GET: GoodsAllocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var disaster = new SelectList(_context.DisasterType.OrderBy(l => l.disasterType)
            .ToDictionary(us => us.Id, us => us.disasterType), "Value", "Value");
            ViewBag.disastertypes = disaster;

            if (id == null)
            {
                return NotFound();
            }

            var goodsAllocation = await _context.GoodsAllocation.FindAsync(id);
            if (goodsAllocation == null)
            {
                return NotFound();
            }
            return View(goodsAllocation);
        }

        // POST: GoodsAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,goodType,dateAllocated,quantity,pricePerItem,disasterType")] GoodsAllocation goodsAllocation)
        {
            if (id != goodsAllocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsAllocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsAllocationExists(goodsAllocation.Id))
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
            return View(goodsAllocation);
        }

        // GET: GoodsAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsAllocation = await _context.GoodsAllocation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsAllocation == null)
            {
                return NotFound();
            }

            return View(goodsAllocation);
        }

        // POST: GoodsAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goodsAllocation = await _context.GoodsAllocation.FindAsync(id);
            _context.GoodsAllocation.Remove(goodsAllocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsAllocationExists(int id)
        {
            return _context.GoodsAllocation.Any(e => e.Id == id);
        }
    }
}
