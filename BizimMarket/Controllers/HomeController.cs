using BizimMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BizimMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BizimMarketContext _db;

        public HomeController(ILogger<HomeController> logger, BizimMarketContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index(int? kategoriId)
        {
            HomeViewModel vm = new HomeViewModel();
            vm.Kategoriler = _db.Kategoriler.OrderBy(a=>a.KategoriAdi).ToList();
            if (kategoriId==null)
            {
                vm.Urunler = _db.Urunler.ToList();
            }
            else
            {
                vm.Urunler = _db.Urunler.Where(a => a.KategoriId == kategoriId).ToList();

            }
            vm.KategoriId = kategoriId;
            return View(vm);
        }

        public IActionResult Privacy()
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
