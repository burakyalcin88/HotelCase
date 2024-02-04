using Hotel.Domain.Context;
using Hotel.Model.Entities;
using Hotel.Service.Abstractions;
using Hotel.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Service.Operations
{
    public class BinaService : Repository<Bina>, IBinaService
    {
        public BinaService(HotelDbContext context) : base(context)
        {

        }
    }
}