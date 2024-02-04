using Hotel.Domain.Context;
using Hotel.Model.Entities;
using Hotel.Service.Abstractions;
using Hotel.Service.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.Operations
{
    public class UrunDepoService : Repository<UrunDepo>, IUrunDepoService
    {
        public UrunDepoService(HotelDbContext context) : base(context)
        {
        }
    }
}
