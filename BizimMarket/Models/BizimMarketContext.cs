using Microsoft.EntityFrameworkCore;

namespace BizimMarket.Models
{
    public class BizimMarketContext : DbContext
    {
        public BizimMarketContext(DbContextOptions<BizimMarketContext> options) : base(options)
        {

        }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().HasData(
                new Kategori() { KategoriId = 1, KategoriAdi = "Fırın,Pastane" },
                new Kategori() { KategoriId = 2, KategoriAdi = "Meze,Hazır Yemek" },
                new Kategori() { KategoriId = 3, KategoriAdi = "Meyve,Sebze" }
                );


            modelBuilder.Entity<Urun>().HasData(
                 new Urun() { UrunId = 1, UrunAdi = "Minik Sandviç 10'Lu", Fiyat = 22.90m, KategoriId = 1, ResimYolu = "minikSandvic.jpg" },
                 new Urun() { UrunId = 2, UrunAdi = "Papatya Ekmek 300 G (Küçük) ( Yeni )", Fiyat = 9.90m, KategoriId = 1, ResimYolu = "papatyaEkmek.jpg" },
                 new Urun() { UrunId = 3, UrunAdi = "Superfresh 7/24 Fırından Simit 400 G", Fiyat = 24.95m, KategoriId = 2, ResimYolu = "simit.jpg" },
                 new Urun() { UrunId = 4, UrunAdi = "Feast Combo Soğan Halkalı 740 G", Fiyat = 44.90m, KategoriId = 2, ResimYolu = "comboSogan.jpg" },
                 new Urun() { UrunId = 5, UrunAdi = "Domates Kokteyl Kg", Fiyat = 19.90m, KategoriId = 3, ResimYolu = "domates.jpg" },
                 new Urun() { UrunId = 6, UrunAdi = "Karnabahar Kg", Fiyat = 24.95m, KategoriId = 3, ResimYolu = "karnabahar.jpg" },
                 new Urun() { UrunId = 7, UrunAdi = "Biber Acı Şili Kırmızı Kg", Fiyat = 43.90m, KategoriId = 3, ResimYolu = "biber.jpg" }
                );
        }
    }
}
