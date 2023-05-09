﻿using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VeriAnalizi.Data;
using VeriAnalizi.Models;
using Repository = VeriAnalizi.Data.Repository;

namespace VeriAnalizi.Controllers
{
    [Area("Kullanici")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IToastNotification _toast;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, IToastNotification toast, ApplicationDbContext context)
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
        public IActionResult KullaniciIndex()
        {
            var model = new InitialModel();
            return View(model);
        }


        public IActionResult Sorular()

        {

            return View();

        }
        public static IReadOnlyList<CheckboxViewModel> SorulariGetir()
        {
            return new List<CheckboxViewModel>
            {
        new CheckboxViewModel
        {
            Id = 1,
            LabelName = "Bugün ne kadar spor yaptın?",
            IsChecked = true
        },
        new CheckboxViewModel
        {
            Id = 2,
            LabelName = "Hiç",
            IsChecked = false
        },
        new CheckboxViewModel
        {
            Id = 3,
            LabelName = "1 saat",
            IsChecked = true
        },
        new CheckboxViewModel
        {
            Id = 4,
            LabelName = "2 saat+",
            IsChecked = false
        },

        };
        }

        [HttpGet]
        public IActionResult CevapSecimi()
        {
            var model = Repository.SorulariGetir();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Secilen(object _lst)
        {
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