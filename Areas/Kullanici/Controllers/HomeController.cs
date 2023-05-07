using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VeriAnalizi.Data;
using VeriAnalizi.Models;

namespace VeriAnalizi.Controllers
{
    [Area("Kullanici")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        private readonly IToastNotification _toast;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,IToastNotification toast,ApplicationDbContext context)
        {
            _logger = logger;
            _toast = toast;
            _context = context;
        }

        public IActionResult Index()
        {
                 
          
            return View();
        }
        public IActionResult Iletisim()
        {
            return View();
        }
        public IActionResult Hakkinda()
        {
            return View();
        }
        public IActionResult Testler()
        {



            

            return View();
        }
        public IActionResult GunlukDoz()
        {
            return View();
        }
        public IActionResult Sorular()
        {
        //    var sq = from sorular in _context.Set<Sorular>() join cevaplar in _context.Set<Cevaplar>() on sorular.Id equals cevaplar.SoruId select new { sorular, cevaplar };


        //   var ss = sq.ToList();

        //    List<Models.Sorular> ff = ss.Select(x=>x.sorular).ToList();
            return View();

           
        }
        public IActionResult SizdenGelenler()
        {
            var sizden = _context.KullaniciMesajs.ToList();
            return View(sizden);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}