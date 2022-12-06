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
    public class DoiBongsController : Controller
    {
        private readonly OntapContext _context;

        public DoiBongsController(OntapContext context)
        {
            _context = context;
        }

        // GET: DoiBongs
        public async Task<IActionResult> Index()
        {
              return View(await _context.DoiBong.ToListAsync());
        }

        // GET: DoiBongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoiBong == null)
            {
                return NotFound();
            }

            var doiBong = await _context.DoiBong
                .FirstOrDefaultAsync(m => m.MaDoiBong == id);
            if (doiBong == null)
            {
                return NotFound();
            }

            return View(doiBong);
        }

        // GET: DoiBongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoiBongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDoiBong,TenDoiBong")] DoiBong doiBong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doiBong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doiBong);
        }

        // GET: DoiBongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoiBong == null)
            {
                return NotFound();
            }

            var doiBong = await _context.DoiBong.FindAsync(id);
            if (doiBong == null)
            {
                return NotFound();
            }
            return View(doiBong);
        }

        // POST: DoiBongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDoiBong,TenDoiBong")] DoiBong doiBong)
        {
            if (id != doiBong.MaDoiBong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doiBong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoiBongExists(doiBong.MaDoiBong))
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
            return View(doiBong);
        }

        // GET: DoiBongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoiBong == null)
            {
                return NotFound();
            }

            var doiBong = await _context.DoiBong
                .FirstOrDefaultAsync(m => m.MaDoiBong == id);
            if (doiBong == null)
            {
                return NotFound();
            }

            return View(doiBong);
        }

        // POST: DoiBongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoiBong == null)
            {
                return Problem("Entity set 'OntapContext.DoiBong'  is null.");
            }
            var doiBong = await _context.DoiBong.FindAsync(id);
            if (doiBong != null)
            {
                _context.DoiBong.Remove(doiBong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoiBongExists(int id)
        {
          return _context.DoiBong.Any(e => e.MaDoiBong == id);
        }
    }
}
