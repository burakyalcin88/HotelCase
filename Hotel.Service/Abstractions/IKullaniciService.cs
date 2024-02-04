using Hotel.Model.Entities;
using Hotel.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.Abstractions
{
    public interface IKullaniciService
    {
        Task<Kullanici> Login(string kullaniciAdi, string sifre);
    }
}
