using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BizimMarket.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }

        [Required, MaxLength(200)]
        public string KategoriAdi { get; set; }

        public List<Urun> Urunler { get; set; }
    }
}
