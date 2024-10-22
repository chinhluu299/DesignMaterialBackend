using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExchangeRatesController : Controller
    {
        private readonly DesignMaterialDbContext _context;

        public ExchangeRatesController(DesignMaterialDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ExchangeRates
        public async Task<IActionResult> Index()
        {
            var designMaterialDbContext = _context.ExchangeRates.Include(e => e.CurrencyUnit);
            return View(await designMaterialDbContext.ToListAsync());
        }

        // GET: Admin/ExchangeRates/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates
                .Include(e => e.CurrencyUnit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }

        // GET: Admin/ExchangeRates/Create
        public IActionResult Create()
        {
            ViewData["CurrencyUnitId"] = new SelectList(_context.CurrencyUnits, "Id", "Unit");
            return View();
        }

        // POST: Admin/ExchangeRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rate,CreateAt,UpdateAt,Active,CurrencyUnitId")] ExchangeRate exchangeRate)
        {
            if (ModelState.IsValid)
            {
                exchangeRate.Id = Guid.NewGuid();
                _context.Add(exchangeRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrencyUnitId"] = new SelectList(_context.CurrencyUnits, "Id", "Unit", exchangeRate.CurrencyUnitId);
            return View(exchangeRate);
        }

        // GET: Admin/ExchangeRates/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates.FindAsync(id);
            if (exchangeRate == null)
            {
                return NotFound();
            }
            ViewData["CurrencyUnitId"] = new SelectList(_context.CurrencyUnits, "Id", "Unit", exchangeRate.CurrencyUnitId);
            return View(exchangeRate);
        }

        // POST: Admin/ExchangeRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Rate,CreateAt,UpdateAt,Active,CurrencyUnitId")] ExchangeRate exchangeRate)
        {
            if (id != exchangeRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exchangeRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExchangeRateExists(exchangeRate.Id))
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
            ViewData["CurrencyUnitId"] = new SelectList(_context.CurrencyUnits, "Id", "Unit", exchangeRate.CurrencyUnitId);
            return View(exchangeRate);
        }

        // GET: Admin/ExchangeRates/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRates
                .Include(e => e.CurrencyUnit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }

        // POST: Admin/ExchangeRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var exchangeRate = await _context.ExchangeRates.FindAsync(id);
            if (exchangeRate != null)
            {
                _context.ExchangeRates.Remove(exchangeRate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExchangeRateExists(Guid id)
        {
            return _context.ExchangeRates.Any(e => e.Id == id);
        }
    }
}
