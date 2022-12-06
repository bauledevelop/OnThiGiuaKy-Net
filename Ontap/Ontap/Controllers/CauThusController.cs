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
    public class CauThusController : Controller
    {
        private readonly OntapContext _context;

        public CauThusController(OntapContext context)
        {
            _context = context;
        }

        // GET: CauThus
        public async Task<IActionResult> Index()
        {
            var ontapContext = _context.CauThu.Include(c => c.DoiBong).Include(c => c.ViTri);
            return View(await ontapContext.ToListAsync());
        }

        // GET: CauThus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CauThu == null)
            {
                return NotFound();
            }

            var cauThu = await _context.CauThu
                .Include(c => c.DoiBong)
                .Include(c => c.ViTri)
                .FirstOrDefaultAsync(m => m.MaCauThu == id);
            if (cauThu == null)
            {
                return NotFound();
            }

            return View(cauThu);
        }

        // GET: CauThus/Create
        public IActionResult Create()
        {
            ViewData["MaDoiBong"] = new SelectList(_context.DoiBong, "MaDoiBong", "MaDoiBong");
            ViewData["MaViTri"] = new SelectList(_context.ViTri, "MaViTri", "TenViTri");
            return View();
        }

        // POST: CauThus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCauThu,TenCauThu,Soao,MaViTri,MaDoiBong")] CauThu cauThu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cauThu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDoiBong"] = new SelectList(_context.DoiBong, "MaDoiBong", "MaDoiBong", cauThu.MaDoiBong);
            ViewData["MaViTri"] = new SelectList(_context.ViTri, "MaViTri", "TenViTri", cauThu.MaViTri);
            return View(cauThu);
        }

        // GET: CauThus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CauThu == null)
            {
                return NotFound();
            }

            var cauThu = await _context.CauThu.FindAsync(id);
            if (cauThu == null)
            {
                return NotFound();
            }
            ViewData["MaDoiBong"] = new SelectList(_context.DoiBong, "MaDoiBong", "MaDoiBong", cauThu.MaDoiBong);
            ViewData["MaViTri"] = new SelectList(_context.ViTri, "MaViTri", "TenViTri", cauThu.MaViTri);
            return View(cauThu);
        }

        // POST: CauThus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCauThu,TenCauThu,Soao,MaViTri,MaDoiBong")] CauThu cauThu)
        {
            if (id != cauThu.MaCauThu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cauThu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CauThuExists(cauThu.MaCauThu))
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
            ViewData["MaDoiBong"] = new SelectList(_context.DoiBong, "MaDoiBong", "MaDoiBong", cauThu.MaDoiBong);
            ViewData["MaViTri"] = new SelectList(_context.ViTri, "MaViTri", "TenViTri", cauThu.MaViTri);
            return View(cauThu);
        }

        // GET: CauThus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CauThu == null)
            {
                return NotFound();
            }

            var cauThu = await _context.CauThu
                .Include(c => c.DoiBong)
                .Include(c => c.ViTri)
                .FirstOrDefaultAsync(m => m.MaCauThu == id);
            if (cauThu == null)
            {
                return NotFound();
            }

            return View(cauThu);
        }

        // POST: CauThus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CauThu == null)
            {
                return Problem("Entity set 'OntapContext.CauThu'  is null.");
            }
            var cauThu = await _context.CauThu.FindAsync(id);
            if (cauThu != null)
            {
                _context.CauThu.Remove(cauThu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CauThuExists(int id)
        {
          return _context.CauThu.Any(e => e.MaCauThu == id);
        }
    }
}
