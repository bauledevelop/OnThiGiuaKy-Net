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
    public class TranDausController : Controller
    {
        private readonly OntapContext _context;

        public TranDausController(OntapContext context)
        {
            _context = context;
        }

        // GET: TranDaus
        public async Task<IActionResult> Index()
        {
            var ontapContext = _context.TranDau.Include(t => t.DoiBong1).Include(t => t.DoiBong2).Include(t => t.SanVanDong);
            return View(await ontapContext.ToListAsync());
        }

        // GET: TranDaus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TranDau == null)
            {
                return NotFound();
            }

            var tranDau = await _context.TranDau
                .Include(t => t.DoiBong1)
                .Include(t => t.DoiBong2)
                .Include(t => t.SanVanDong)
                .FirstOrDefaultAsync(m => m.MaTranDau == id);
            if (tranDau == null)
            {
                return NotFound();
            }

            return View(tranDau);
        }

        // GET: TranDaus/Create
        public IActionResult Create()
        {
            ViewData["MaDoiBong1"] = new SelectList(_context.DoiBong, "MaDoiBong", "MaDoiBong");
            ViewData["MaDoiBong2"] = new SelectList(_context.DoiBong, "MaDoiBong", "MaDoiBong");
            ViewData["MaSan"] = new SelectList(_context.SanVanDong, "MaSan", "MaSan");
            return View();
        }

        // POST: TranDaus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTranDau,MaDoiBong1,MaDoiBong2,MaSan")] TranDau tranDau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tranDau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDoiBong1"] = new SelectList(_context.DoiBong, "MaDoiBong", "MaDoiBong", tranDau.MaDoiBong1);
            ViewData["MaDoiBong2"] = new SelectList(_context.DoiBong, "MaDoiBong", "MaDoiBong", tranDau.MaDoiBong2);
            ViewData["MaSan"] = new SelectList(_context.SanVanDong, "MaSan", "MaSan", tranDau.MaSan);
            return View(tranDau);
        }

        // GET: TranDaus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TranDau == null)
            {
                return NotFound();
            }

            var tranDau = await _context.TranDau.FindAsync(id);
            if (tranDau == null)
            {
                return NotFound();
            }
            ViewData["MaDoiBong1"] = new SelectList(_context.DoiBong, "MaDoiBong", "MaDoiBong", tranDau.MaDoiBong1);
            ViewData["MaDoiBong2"] = new SelectList(_context.DoiBong, "MaDoiBong", "MaDoiBong", tranDau.MaDoiBong2);
            ViewData["MaSan"] = new SelectList(_context.SanVanDong, "MaSan", "MaSan", tranDau.MaSan);
            return View(tranDau);
        }

        // POST: TranDaus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTranDau,MaDoiBong1,MaDoiBong2,MaSan")] TranDau tranDau)
        {
            if (id != tranDau.MaTranDau)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tranDau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranDauExists(tranDau.MaTranDau))
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
            ViewData["MaDoiBong1"] = new SelectList(_context.DoiBong, "MaDoiBong", "MaDoiBong", tranDau.MaDoiBong1);
            ViewData["MaDoiBong2"] = new SelectList(_context.DoiBong, "MaDoiBong", "MaDoiBong", tranDau.MaDoiBong2);
            ViewData["MaSan"] = new SelectList(_context.SanVanDong, "MaSan", "MaSan", tranDau.MaSan);
            return View(tranDau);
        }

        // GET: TranDaus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TranDau == null)
            {
                return NotFound();
            }

            var tranDau = await _context.TranDau
                .Include(t => t.DoiBong1)
                .Include(t => t.DoiBong2)
                .Include(t => t.SanVanDong)
                .FirstOrDefaultAsync(m => m.MaTranDau == id);
            if (tranDau == null)
            {
                return NotFound();
            }

            return View(tranDau);
        }

        // POST: TranDaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TranDau == null)
            {
                return Problem("Entity set 'OntapContext.TranDau'  is null.");
            }
            var tranDau = await _context.TranDau.FindAsync(id);
            if (tranDau != null)
            {
                _context.TranDau.Remove(tranDau);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranDauExists(int id)
        {
          return _context.TranDau.Any(e => e.MaTranDau == id);
        }
    }
}
