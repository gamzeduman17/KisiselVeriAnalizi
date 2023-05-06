using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Diagnostics;
using VeriAnalizi.Models;

namespace VeriAnalizi.Controllers
{
    [Area("Kullanici")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IToastNotification _toast;

        public HomeController(ILogger<HomeController> logger,IToastNotification toast)
        {
            _logger = logger;
            _toast = toast;
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
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}