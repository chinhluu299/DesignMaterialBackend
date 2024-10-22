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
    public class PaymentAccountsController : Controller
    {
        private readonly DesignMaterialDbContext _context;

        public PaymentAccountsController(DesignMaterialDbContext context)
        {
            _context = context;
        }

        // GET: Admin/PaymentAccounts
        public async Task<IActionResult> Index()
        {
            var designMaterialDbContext = _context.PaymentAccounts.Include(p => p.PaymentType);
            return View(await designMaterialDbContext.ToListAsync());
        }

        // GET: Admin/PaymentAccounts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentAccount = await _context.PaymentAccounts
                .Include(p => p.PaymentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentAccount == null)
            {
                return NotFound();
            }

            return View(paymentAccount);
        }

        // GET: Admin/PaymentAccounts/Create
        public IActionResult Create()
        {
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "Id", "Name");
            return View();
        }

        // POST: Admin/PaymentAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AccountNumber,BankName,MomoNumber,ZaloNumber,UpdatedAt,PaymentTypeId")] PaymentAccount paymentAccount)
        {
            if (ModelState.IsValid)
            {
                paymentAccount.Id = Guid.NewGuid();
                _context.Add(paymentAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "Id", "Name", paymentAccount.PaymentTypeId);
            return View(paymentAccount);
        }

        // GET: Admin/PaymentAccounts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentAccount = await _context.PaymentAccounts.FindAsync(id);
            if (paymentAccount == null)
            {
                return NotFound();
            }
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "Id", "Name", paymentAccount.PaymentTypeId);
            return View(paymentAccount);
        }

        // POST: Admin/PaymentAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,AccountNumber,BankName,MomoNumber,ZaloNumber,UpdatedAt,PaymentTypeId")] PaymentAccount paymentAccount)
        {
            if (id != paymentAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentAccountExists(paymentAccount.Id))
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
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "Id", "Name", paymentAccount.PaymentTypeId);
            return View(paymentAccount);
        }

        // GET: Admin/PaymentAccounts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentAccount = await _context.PaymentAccounts
                .Include(p => p.PaymentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentAccount == null)
            {
                return NotFound();
            }

            return View(paymentAccount);
        }

        // POST: Admin/PaymentAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var paymentAccount = await _context.PaymentAccounts.FindAsync(id);
            if (paymentAccount != null)
            {
                _context.PaymentAccounts.Remove(paymentAccount);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentAccountExists(Guid id)
        {
            return _context.PaymentAccounts.Any(e => e.Id == id);
        }
    }
}
