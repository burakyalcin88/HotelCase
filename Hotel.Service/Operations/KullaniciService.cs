using Hotel.Domain.Context;
using Hotel.Model.Entities;
using Hotel.Service.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Service.Operations
{
    public class KullaniciService : IKullaniciService
    {
        private HotelDbContext _hotelDbContext;
        public KullaniciService(HotelDbContext context)
        {
            this._hotelDbContext = context;
        }

        public async Task<Kullanici> Login(string kullaniciAdi, string sifre)
        {
            return await _hotelDbContext.Kullanicilar.Where(y => y.KullaniciAdi.Equals(kullaniciAdi) && y.Sifre.Equals(sifre)).FirstOrDefaultAsync();
        }
    }
}