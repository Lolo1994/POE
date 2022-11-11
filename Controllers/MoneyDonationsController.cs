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
    public class MoneyDonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoneyDonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MoneyDonations
        public async Task<IActionResult> Index()
        {
            return View(await _context.MoneyDonations.ToListAsync());
        }

        // GET: MoneyDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyDonations = await _context.MoneyDonations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moneyDonations == null)
            {
                return NotFound();
            }

            return View(moneyDonations);
        }

        // GET: MoneyDonations/Create
        [Authorize]
        public IActionResult Create()
        {
            DisasterType dt = new DisasterType();
            var disaster = new SelectList(_context.DisasterType.OrderBy(l => l.disasterType)
               .ToDictionary(us => us.Id, us => us.disasterType), "Value", "Value");
           ViewBag.disastertypes = disaster;
            return View();
        }

        // POST: MoneyDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,donationAmount,dateReceived,donorName,isAnonymous,disasteType")] MoneyDonations moneyDonations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moneyDonations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moneyDonations);
        }

        // GET: MoneyDonations/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            DisasterType dt = new DisasterType();
            var disaster = new SelectList(_context.DisasterType.OrderBy(l => l.disasterType)
               .ToDictionary(us => us.Id, us => us.disasterType), "Value", "Value");
            ViewBag.disastertypes = disaster;
            if (id == null)
            {
                return NotFound();
            }

            var moneyDonations = await _context.MoneyDonations.FindAsync(id);
            if (moneyDonations == null)
            {
                return NotFound();
            }
            return View(moneyDonations);
        }

        // POST: MoneyDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,donationAmount,dateReceived,donorName,isAnonymous,disasteType")] MoneyDonations moneyDonations)
        {
            if (id != moneyDonations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moneyDonations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoneyDonationsExists(moneyDonations.Id))
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
            return View(moneyDonations);
        }

        // GET: MoneyDonations/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyDonations = await _context.MoneyDonations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moneyDonations == null)
            {
                return NotFound();
            }

            return View(moneyDonations);
        }

        // POST: MoneyDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moneyDonations = await _context.MoneyDonations.FindAsync(id);
            _context.MoneyDonations.Remove(moneyDonations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoneyDonationsExists(int id)
        {
            return _context.MoneyDonations.Any(e => e.Id == id);
        }
    }
}
