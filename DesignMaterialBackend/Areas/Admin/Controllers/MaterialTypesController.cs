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
    public class MaterialTypesController : Controller
    {
        private readonly DesignMaterialDbContext _context;

        public MaterialTypesController(DesignMaterialDbContext context)
        {
            _context = context;
        }

        // GET: Admin/MaterialTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaterialTypes.ToListAsync());
        }

        // GET: Admin/MaterialTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialType = await _context.MaterialTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materialType == null)
            {
                return NotFound();
            }

            return View(materialType);
        }

        // GET: Admin/MaterialTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MaterialTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Other,CreateAt,UpdateAt")] MaterialType materialType)
        {
            if (ModelState.IsValid)
            {
                materialType.Id = Guid.NewGuid();
                _context.Add(materialType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialType);
        }

        // GET: Admin/MaterialTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialType = await _context.MaterialTypes.FindAsync(id);
            if (materialType == null)
            {
                return NotFound();
            }
            return View(materialType);
        }

        // POST: Admin/MaterialTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Other,CreateAt,UpdateAt")] MaterialType materialType)
        {
            if (id != materialType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialTypeExists(materialType.Id))
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
            return View(materialType);
        }

        // GET: Admin/MaterialTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialType = await _context.MaterialTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materialType == null)
            {
                return NotFound();
            }

            return View(materialType);
        }

        // POST: Admin/MaterialTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var materialType = await _context.MaterialTypes.FindAsync(id);
            if (materialType != null)
            {
                _context.MaterialTypes.Remove(materialType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialTypeExists(Guid id)
        {
            return _context.MaterialTypes.Any(e => e.Id == id);
        }
    }
}
