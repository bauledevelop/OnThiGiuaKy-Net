using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ontap.Data;

namespace Ontap.Controllers
{
    public class ViTrisController : Controller
    {
        private readonly OntapContext _context;

        public ViTrisController(OntapContext context)
        {
            _context = context;
        }

        // GET: ViTris
        public async Task<IActionResult> Index()
        {
              return View(await _context.ViTri.ToListAsync());
        }

        // GET: ViTris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ViTri == null)
            {
                return NotFound();
            }

            var viTri = await _context.ViTri
                .FirstOrDefaultAsync(m => m.MaViTri == id);
            if (viTri == null)
            {
                return NotFound();
            }

            return View(viTri);
        }

        // GET: ViTris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ViTris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaViTri,TenViTri")] ViTri viTri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viTri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viTri);
        }

        // GET: ViTris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ViTri == null)
            {
                return NotFound();
            }

            var viTri = await _context.ViTri.FindAsync(id);
            if (viTri == null)
            {
                return NotFound();
            }
            return View(viTri);
        }

        // POST: ViTris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaViTri,TenViTri")] ViTri viTri)
        {
            if (id != viTri.MaViTri)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viTri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViTriExists(viTri.MaViTri))
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
            return View(viTri);
        }

        // GET: ViTris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ViTri == null)
            {
                return NotFound();
            }

            var viTri = await _context.ViTri
                .FirstOrDefaultAsync(m => m.MaViTri == id);
            if (viTri == null)
            {
                return NotFound();
            }

            return View(viTri);
        }

        // POST: ViTris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ViTri == null)
            {
                return Problem("Entity set 'OntapContext.ViTri'  is null.");
            }
            var viTri = await _context.ViTri.FindAsync(id);
            if (viTri != null)
            {
                _context.ViTri.Remove(viTri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViTriExists(int id)
        {
          return _context.ViTri.Any(e => e.MaViTri == id);
        }
    }
}
