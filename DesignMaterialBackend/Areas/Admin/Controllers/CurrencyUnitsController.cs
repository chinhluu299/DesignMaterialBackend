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
    public class CurrencyUnitsController : Controller
    {
        private readonly DesignMaterialDbContext _context;

        public CurrencyUnitsController(DesignMaterialDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CurrencyUnits
        public async Task<IActionResult> Index()
        {
            return View(await _context.CurrencyUnits.ToListAsync());
        }

        // GET: Admin/CurrencyUnits/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencyUnit = await _context.CurrencyUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currencyUnit == null)
            {
                return NotFound();
            }

            return View(currencyUnit);
        }

        // GET: Admin/CurrencyUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CurrencyUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Unit,Description,CreateAt")] CurrencyUnit currencyUnit)
        {
            if (ModelState.IsValid)
            {
                currencyUnit.Id = Guid.NewGuid();
                _context.Add(currencyUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currencyUnit);
        }

        // GET: Admin/CurrencyUnits/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencyUnit = await _context.CurrencyUnits.FindAsync(id);
            if (currencyUnit == null)
            {
                return NotFound();
            }
            return View(currencyUnit);
        }

        // POST: Admin/CurrencyUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Unit,Description,CreateAt")] CurrencyUnit currencyUnit)
        {
            if (id != currencyUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currencyUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrencyUnitExists(currencyUnit.Id))
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
            return View(currencyUnit);
        }

        // GET: Admin/CurrencyUnits/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencyUnit = await _context.CurrencyUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currencyUnit == null)
            {
                return NotFound();
            }

            return View(currencyUnit);
        }

        // POST: Admin/CurrencyUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var currencyUnit = await _context.CurrencyUnits.FindAsync(id);
            if (currencyUnit != null)
            {
                _context.CurrencyUnits.Remove(currencyUnit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrencyUnitExists(Guid id)
        {
            return _context.CurrencyUnits.Any(e => e.Id == id);
        }
    }
}
