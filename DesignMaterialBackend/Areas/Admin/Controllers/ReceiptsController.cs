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
    public class ReceiptsController : Controller
    {
        private readonly DesignMaterialDbContext _context;

        public ReceiptsController(DesignMaterialDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Receipts
        public async Task<IActionResult> Index()
        {
            var designMaterialDbContext = _context.Receipts.Include(r => r.PaymentAccount).Include(r => r.User);
            return View(await designMaterialDbContext.ToListAsync());
        }

        // GET: Admin/Receipts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipts
                .Include(r => r.PaymentAccount)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // GET: Admin/Receipts/Create
        public IActionResult Create()
        {
            ViewData["PaymentAccountId"] = new SelectList(_context.PaymentAccounts, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Admin/Receipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,TransactionCode,BankAccountName,BankAccountNumber,Amount,Currency,PaymentDate,CreateAt,UpdateAt,PaymentStatus,PaymentAccountId,UserId")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                receipt.Id = Guid.NewGuid();
                _context.Add(receipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentAccountId"] = new SelectList(_context.PaymentAccounts, "Id", "Name", receipt.PaymentAccountId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", receipt.UserId);
            return View(receipt);
        }

        // GET: Admin/Receipts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipts.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }
            ViewData["PaymentAccountId"] = new SelectList(_context.PaymentAccounts, "Id", "Name", receipt.PaymentAccountId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", receipt.UserId);
            return View(receipt);
        }

        // POST: Admin/Receipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Content,TransactionCode,BankAccountName,BankAccountNumber,Amount,Currency,PaymentDate,CreateAt,UpdateAt,PaymentStatus,PaymentAccountId,UserId")] Receipt receipt)
        {
            if (id != receipt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptExists(receipt.Id))
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
            ViewData["PaymentAccountId"] = new SelectList(_context.PaymentAccounts, "Id", "Name", receipt.PaymentAccountId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", receipt.UserId);
            return View(receipt);
        }

        // GET: Admin/Receipts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipts
                .Include(r => r.PaymentAccount)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // POST: Admin/Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var receipt = await _context.Receipts.FindAsync(id);
            if (receipt != null)
            {
                _context.Receipts.Remove(receipt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptExists(Guid id)
        {
            return _context.Receipts.Any(e => e.Id == id);
        }
    }
}
