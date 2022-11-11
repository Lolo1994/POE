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
    public class GoodsCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoodsCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.GoodsCategories.ToListAsync());
        }

        // GET: GoodsCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsCategories = await _context.GoodsCategories
                .FirstOrDefaultAsync(m => m.id == id);
            if (goodsCategories == null)
            {
                return NotFound();
            }

            return View(goodsCategories);
        }

        // GET: GoodsCategories/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoodsCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,goodsCategory")] GoodsCategories goodsCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goodsCategories);
        }

        // GET: GoodsCategories/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsCategories = await _context.GoodsCategories.FindAsync(id);
            if (goodsCategories == null)
            {
                return NotFound();
            }
            return View(goodsCategories);
        }

        // POST: GoodsCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,goodsCategory")] GoodsCategories goodsCategories)
        {
            if (id != goodsCategories.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsCategoriesExists(goodsCategories.id))
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
            return View(goodsCategories);
        }

        // GET: GoodsCategories/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsCategories = await _context.GoodsCategories
                .FirstOrDefaultAsync(m => m.id == id);
            if (goodsCategories == null)
            {
                return NotFound();
            }

            return View(goodsCategories);
        }

        // POST: GoodsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goodsCategories = await _context.GoodsCategories.FindAsync(id);
            _context.GoodsCategories.Remove(goodsCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsCategoriesExists(int id)
        {
            return _context.GoodsCategories.Any(e => e.id == id);
        }
    }
}
