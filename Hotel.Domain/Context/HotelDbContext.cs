using Hotel.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Domain.Context
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }

        public DbSet<Oda> Odalar { get; set; }
        public DbSet<Depo> Depoalar { get; set; }
        public DbSet<Bina> Binalar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<UrunDepo> UrunDepolar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}