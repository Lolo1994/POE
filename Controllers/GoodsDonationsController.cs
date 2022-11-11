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
    public class GoodsDonationsController : Controller
    {
        private readonly ApplicationDbContext _context;


      

        public GoodsDonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoodsDonations
        public async Task<IActionResult> Index()
        {
          
            return View(await _context.GoodsDonations.ToListAsync());
        }

        // GET: GoodsDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsDonations = await _context.GoodsDonations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsDonations == null)
            {
                return NotFound();
            }

            return View(goodsDonations);
        }

        // GET: GoodsDonations/Create
        [Authorize]
        public IActionResult Create()
        {
            DisasterType dt = new DisasterType();
            GoodsCategories gc = new GoodsCategories();

            var li = new SelectList(_context.GoodsCategories.OrderBy(l => l.goodsCategory)
                .ToDictionary(us => us.id, us => us.goodsCategory), "Key", "Value");

            var disaster = new SelectList(_context.DisasterType.OrderBy(l => l.disasterType)
               .ToDictionary(us => us.Id, us => us.disasterType), "Key", "Value");





            //List<DisasterType> disaster = new List<DisasterType>();
            //List<GoodsCategories> li = new List<GoodsCategories>();
            
            

           // li = _context.GoodsCategories.ToList();
           //disaster = _context.DisasterType.ToList();

            ViewBag.listofitems = li;
            ViewBag.disastertypes = disaster;
            return View();
        }

        // POST: GoodsDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,itemName,dateReceived,itemNumber,itemType,isAnonymous,disasteType")] GoodsDonations goodsDonations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsDonations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goodsDonations);
        }

        // GET: GoodsDonations/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            DisasterType dt = new DisasterType();
            GoodsCategories gc = new GoodsCategories();

            var li = new SelectList(_context.GoodsCategories.OrderBy(l => l.goodsCategory)
                .ToDictionary(us => us.id, us => us.goodsCategory), "Value", "Value");

            var disaster = new SelectList(_context.DisasterType.OrderBy(l => l.disasterType)
               .ToDictionary(us => us.Id, us => us.disasterType), "Value", "Value");

            ViewBag.listofitems = li;
            ViewBag.disastertypes = disaster;

            if (id == null)
            {
                return NotFound();
            }

            var goodsDonations = await _context.GoodsDonations.FindAsync(id);
            if (goodsDonations == null)
            {
                return NotFound();
            }
            return View(goodsDonations);
        }

        // POST: GoodsDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,itemName,dateReceived,itemNumber,itemType,isAnonymous,disasteType")] GoodsDonations goodsDonations)
        {
            if (id != goodsDonations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsDonations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsDonationsExists(goodsDonations.Id))
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
            return View(goodsDonations);
        }

        // GET: GoodsDonations/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsDonations = await _context.GoodsDonations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsDonations == null)
            {
                return NotFound();
            }

            return View(goodsDonations);
        }

        // POST: GoodsDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goodsDonations = await _context.GoodsDonations.FindAsync(id);
            _context.GoodsDonations.Remove(goodsDonations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsDonationsExists(int id)
        {
            return _context.GoodsDonations.Any(e => e.Id == id);
        }
    }
}
