using Hotel.Domain.Context;
using Hotel.Model.Entities;
using Hotel.Service.Abstractions;
using Hotel.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Service.Operations
{
    public class UrunService : Repository<Urun>, IUrunService
    {
        public UrunService(HotelDbContext context) : base(context)
        {
        }
    }
}