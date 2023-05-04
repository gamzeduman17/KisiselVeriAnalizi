using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeriAnalizi.Data;
using VeriAnalizi.Models;

namespace VeriAnalizi.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class YorumlarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _whe;

        public YorumlarController(ApplicationDbContext context,IWebHostEnvironment whe)
        {
            _context = context;
            _whe = whe;
        }

        // GET: Yonetici/Yorumlar
        public async Task<IActionResult> Index()
        {
              return _context.Yorumlars != null ? 
                          View(await _context.Yorumlars.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Yorumlars'  is null.");
        }

        // GET: Yonetici/Yorumlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Yorumlars == null)
            {
                return NotFound();
            }

            var yorumlar = await _context.Yorumlars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yorumlar == null)
            {
                return NotFound();
            }

            return View(yorumlar);
        }

        // GET: Yonetici/Yorumlar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yonetici/Yorumlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Yorum,Email,Image,YorumId")] Yorumlar yorumlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorumlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yorumlar);
        }

        // GET: Yonetici/Yorumlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Yorumlars == null)
            {
                return NotFound();
            }

            var yorumlar = await _context.Yorumlars.FindAsync(id);
            if (yorumlar == null)
            {
                return NotFound();
            }
            return View(yorumlar);
        }

        // POST: Yonetici/Yorumlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Yorum,Email,Image,YorumId")] Yorumlar yorumlar)
        {
            if (id != yorumlar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorumlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumlarExists(yorumlar.Id))
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
            return View(yorumlar);
        }

        // GET: Yonetici/Yorumlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Yorumlars == null)
            {
                return NotFound();
            }

            var yorumlar = await _context.Yorumlars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yorumlar == null)
            {
                return NotFound();
            }

            return View(yorumlar);
        }

        // POST: Yonetici/Yorumlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Yorumlars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Yorumlars'  is null.");
            }
            var yorumlar = await _context.Yorumlars.FindAsync(id);
            if (yorumlar != null)
            {
                _context.Yorumlars.Remove(yorumlar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YorumlarExists(int id)
        {
          return (_context.Yorumlars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
