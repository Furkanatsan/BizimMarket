using BizimMarket.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BizimMarket.Areas.Admin.Models
{
    public class YeniUrunViewModel
    {
        [Required(ErrorMessage ="Ad alanı zorunludur.")]
        public string UrunAdi { get; set; }
        [Required(ErrorMessage = "Fiyat alanı zorunludur.")]
        public int Fiyat { get; set; }
        [Required(ErrorMessage = "Fiyat alanı zorunludur.")]
        public int KategoriId { get; set; }
        [Required(ErrorMessage ="resim seçiniz")]
        [GecerliResim(ResimMaxMb =2)]//custom validation attribute
        public IFormFile Resim { get; set; } 
    }
}
