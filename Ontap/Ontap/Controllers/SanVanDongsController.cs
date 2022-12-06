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
    public class SanVanDongsController : Controller
    {
        private readonly OntapContext _context;

        public SanVanDongsController(OntapContext context)
        {
            _context = context;
        }

        // GET: SanVanDongs
        public async Task<IActionResult> Index()
        {
              return View(await _context.SanVanDong.ToListAsync());
        }

        // GET: SanVanDongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SanVanDong == null)
            {
                return NotFound();
            }

            var sanVanDong = await _context.SanVanDong
                .FirstOrDefaultAsync(m => m.MaSan == id);
            if (sanVanDong == null)
            {
                return NotFound();
            }

            return View(sanVanDong);
        }

        // GET: SanVanDongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SanVanDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSan,TenSan")] SanVanDong sanVanDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanVanDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanVanDong);
        }

        // GET: SanVanDongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SanVanDong == null)
            {
                return NotFound();
            }

            var sanVanDong = await _context.SanVanDong.FindAsync(id);
            if (sanVanDong == null)
            {
                return NotFound();
            }
            return View(sanVanDong);
        }

        // POST: SanVanDongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSan,TenSan")] SanVanDong sanVanDong)
        {
            if (id != sanVanDong.MaSan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanVanDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanVanDongExists(sanVanDong.MaSan))
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
            return View(sanVanDong);
        }

        // GET: SanVanDongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SanVanDong == null)
            {
                return NotFound();
            }

            var sanVanDong = await _context.SanVanDong
                .FirstOrDefaultAsync(m => m.MaSan == id);
            if (sanVanDong == null)
            {
                return NotFound();
            }

            return View(sanVanDong);
        }

        // POST: SanVanDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SanVanDong == null)
            {
                return Problem("Entity set 'OntapContext.SanVanDong'  is null.");
            }
            var sanVanDong = await _context.SanVanDong.FindAsync(id);
            if (sanVanDong != null)
            {
                _context.SanVanDong.Remove(sanVanDong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanVanDongExists(int id)
        {
          return _context.SanVanDong.Any(e => e.MaSan == id);
        }
    }
}
