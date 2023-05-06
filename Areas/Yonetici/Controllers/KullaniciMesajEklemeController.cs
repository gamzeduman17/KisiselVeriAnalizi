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
    public class KullaniciMesajEklemeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _whe;

        public KullaniciMesajEklemeController(ApplicationDbContext context,IWebHostEnvironment whe)
        {
            _context = context;
            _whe = whe;
        }

        // GET: Yonetici/KullaniciMesajEkleme
        public async Task<IActionResult> Index()
        {
              return _context.KullaniciMesajs != null ? 
                          View(await _context.KullaniciMesajs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.KullaniciMesajs'  is null.");
        }

        // GET: Yonetici/KullaniciMesajEkleme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KullaniciMesajs == null)
            {
                return NotFound();
            }

            var kullaniciMesajEkleme = await _context.KullaniciMesajs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kullaniciMesajEkleme == null)
            {
                return NotFound();
            }

            return View(kullaniciMesajEkleme);
        }

        // GET: Yonetici/KullaniciMesajEkleme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yonetici/KullaniciMesajEkleme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KullaniciMesajEkleme kullaniciMesajEkleme)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                //IF DOSYA KONTROLÜ YAPTIM
                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    //RESİM EKLEMEK İÇİN PATH METODU KULLANILIR
                    //RESMİ KAYDETMEK İSTEDİĞİM DOSYA YOLUNU BELİRTTİM
                    var uploads = Path.Combine(_whe.WebRootPath, @"Website\images");
                    var extn = Path.GetExtension(files[0].FileName);

                    if (kullaniciMesajEkleme.Image != null)
                    {
                        var ImagePath = Path.Combine(_whe.WebRootPath, kullaniciMesajEkleme.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(ImagePath))
                        {
                            System.IO.File.Delete(ImagePath);
                        }
                    }
                    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extn), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    kullaniciMesajEkleme.Image = @"\Website\images\" + fileName + extn;
                }
                _context.Add(kullaniciMesajEkleme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kullaniciMesajEkleme);
        }

        // GET: Yonetici/KullaniciMesajEkleme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KullaniciMesajs == null)
            {
                return NotFound();
            }

            var kullaniciMesajEkleme = await _context.KullaniciMesajs.FindAsync(id);
            if (kullaniciMesajEkleme == null)
            {
                return NotFound();
            }
            return View(kullaniciMesajEkleme);
        }

        // POST: Yonetici/KullaniciMesajEkleme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,KullaniciYorumu")] KullaniciMesajEkleme kullaniciMesajEkleme)
        {
            if (id != kullaniciMesajEkleme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kullaniciMesajEkleme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullaniciMesajEklemeExists(kullaniciMesajEkleme.Id))
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
            return View(kullaniciMesajEkleme);
        }

        // GET: Yonetici/KullaniciMesajEkleme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KullaniciMesajs == null)
            {
                return NotFound();
            }

            var kullaniciMesajEkleme = await _context.KullaniciMesajs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kullaniciMesajEkleme == null)
            {
                return NotFound();
            }

            return View(kullaniciMesajEkleme);
        }

        // POST: Yonetici/KullaniciMesajEkleme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KullaniciMesajs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.KullaniciMesajs'  is null.");
            }
            var kullaniciMesajEkleme = await _context.KullaniciMesajs.FindAsync(id);
            if (kullaniciMesajEkleme != null)
            {
                _context.KullaniciMesajs.Remove(kullaniciMesajEkleme);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullaniciMesajEklemeExists(int id)
        {
          return (_context.KullaniciMesajs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
