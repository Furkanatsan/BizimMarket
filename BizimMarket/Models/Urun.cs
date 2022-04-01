using System.ComponentModel.DataAnnotations;

namespace BizimMarket.Models
{
    public class Urun
    {
        public int UrunId { get; set; }

        [Required, MaxLength(200)]
        public string UrunAdi { get; set; }
        public decimal Fiyat  { get; set; }
        public string  ResimYolu  { get; set; }//IformFile

        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
