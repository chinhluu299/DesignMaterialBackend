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
    public class MaterialsController : Controller
    {
        private readonly DesignMaterialDbContext _context;

        public MaterialsController(DesignMaterialDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Materials
        public async Task<IActionResult> Index()
        {
            var designMaterialDbContext = _context.Materials.Include(m => m.MaterialType);
            return View(await designMaterialDbContext.ToListAsync());
        }

        // GET: Admin/Materials/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .Include(m => m.MaterialType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Admin/Materials/Create
        public IActionResult Create()
        {
            ViewData["MaterialTypeId"] = new SelectList(_context.MaterialTypes, "Id", "Name");
            return View();
        }

        // POST: Admin/Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Content,Url,Price,CountDownloaded,CreateAt,UpdateAt,MaterialTypeId")] Material material)
        {
            if (ModelState.IsValid)
            {
                material.Id = Guid.NewGuid();
                _context.Add(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaterialTypeId"] = new SelectList(_context.MaterialTypes, "Id", "Name", material.MaterialTypeId);
            return View(material);
        }

        // GET: Admin/Materials/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            ViewData["MaterialTypeId"] = new SelectList(_context.MaterialTypes, "Id", "Name", material.MaterialTypeId);
            return View(material);
        }

        // POST: Admin/Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,Content,Url,Price,CountDownloaded,CreateAt,UpdateAt,MaterialTypeId")] Material material)
        {
            if (id != material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.Id))
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
            ViewData["MaterialTypeId"] = new SelectList(_context.MaterialTypes, "Id", "Name", material.MaterialTypeId);
            return View(material);
        }

        // GET: Admin/Materials/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .Include(m => m.MaterialType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Admin/Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(Guid id)
        {
            return _context.Materials.Any(e => e.Id == id);
        }
    }
}
