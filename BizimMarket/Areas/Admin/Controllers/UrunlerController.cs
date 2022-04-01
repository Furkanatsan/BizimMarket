using BizimMarket.Areas.Admin.Models;
using BizimMarket.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BizimMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrunlerController : Controller
    {
        private readonly BizimMarketContext _db;
        private readonly IWebHostEnvironment _env;

        public UrunlerController(BizimMarketContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            var urunListesi = _db.Urunler.Include(a=>a.Kategori).ToList();
            return View(urunListesi);
        }
        public IActionResult Yeni()
        {
            ViewBag.Kategoriler = _db.Kategoriler.Select(a => new SelectListItem(a.KategoriAdi, a.KategoriId.ToString())).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Yeni(YeniUrunViewModel vm)
        {
            if (vm.Resim!=null)
            {
                if (ModelState.IsValid)
                {
                    resimKaydet(vm.Resim);

                    Urun urun = new Urun();
                    urun.UrunAdi = vm.UrunAdi;
                    urun.ResimYolu = "resimAdi";
                    urun.KategoriId = vm.KategoriId;
                    urun.Fiyat = vm.Fiyat;

                    _db.Add(urun);
                    _db.SaveChanges();
                    return RedirectToAction("Index");

                }
                KategorileriGetir();
            }
            return View();

        }

        private string resimKaydet(IFormFile resim)
        {
            string resimAdi = Guid.NewGuid() + Path.GetExtension(resim.FileName);

            string kaydetmeYolu = Path.Combine(_env.WebRootPath, "img", resimAdi);


            using (FileStream fs = new FileStream(kaydetmeYolu, FileMode.Create))
            {
               resim.CopyTo(fs);
            }
            return resimAdi;
        }

        private void KategorileriGetir()
        {
            ViewBag.Kategoriler = _db.Kategoriler.Select(a => new SelectListItem(a.KategoriAdi, a.KategoriId.ToString())).ToList();
        }

        public IActionResult Duzenle(int id)
        {
            Urun d = _db.Urunler.Find(id);
            DuzenleUrunViewModel vm = new DuzenleUrunViewModel();//automapper kütüphanesi
            if (d!=null)
            {
                vm.ResimYolu = d.ResimYolu;
                vm.UrunId = d.UrunId;
                vm.KategoriId = d.KategoriId;
                vm.Fiyat = (int)d.Fiyat;
                vm.UrunAdi = d.UrunAdi;
            }
            else
            {
                return NotFound();
            }
            KategorileriGetir();
            return View(vm);
        } 
        [HttpPost]
        public IActionResult Duzenle(DuzenleUrunViewModel vm)
        {

            if (ModelState.IsValid)
            {
                var urun=_db.Urunler.Find(vm.UrunId);
                urun.UrunAdi = vm.UrunAdi;
                urun.Fiyat = vm.Fiyat;
                urun.KategoriId = vm.KategoriId;
                if (vm.Resim!=null)
                {
                    if (!string.IsNullOrEmpty(vm.ResimYolu))
                    {
                        resimSil(vm.ResimYolu);
                    }
                    urun.ResimYolu=resimKaydet(vm.Resim);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);

        }

        private void resimSil(string resimYolu)
        {
            string silmeYolu = Path.Combine(_env.WebRootPath, "img", resimYolu);

            if (System.IO.File.Exists(silmeYolu))
            {
                System.IO.File.Delete(silmeYolu);
            }
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            //ürünü sil
            //ürün resmini fiziksel olarak sil
            var urun = _db.Urunler.Find(id);
            if (urun==null)
            {
                return NotFound();
            }
            else
            {
                _db.Urunler.Remove(urun);
                _db.SaveChanges();
                resimSil(urun.ResimYolu);

                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
