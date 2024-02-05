using Hotel.Model.Entities;
using Hotel.Model.Request;
using Hotel.Model.Response;
using Hotel.Service.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using System.Net;

namespace Hotel.Controllers
{
    [ApiController]
    [Route("bina")]
    public class BinaController : ControllerBase
    {
        private IBinaService _binaService { get; set; }
        public BinaController(IBinaService binaService)
        {
            _binaService = binaService;
        }

        [HttpGet("bina-listesi")]
        [Authorize]
        public IEnumerable<Bina> GetBinaList()
        {
            return _binaService.GetAll().Where(y => !y.IsDeleted);
        }


        [HttpPost("bina-ekle")]
        [Authorize]
        public bool AddBina(BinaRequest bina)
        {
            var binaEntity = new Bina()
            {
                BinaAdi = bina.BinaAdi,
                BinaAdresi = bina.BinaAdresi,
                CreateTime = DateTime.Now
            };

            _binaService.Insert(binaEntity);
            _binaService.Save();

            return true;
        }

        [HttpPost("bina-sil")]
        [Authorize]
        public bool DeleteBina(int binaId)
        {
            var binaResult = _binaService.GetById(binaId);

            if (binaResult != null)
            {
                binaResult.IsDeleted = true;
                binaResult.DeleteTime = DateTime.Now;

                _binaService.Update(binaResult);
                _binaService.Save();

                return true;
            }
            else
                return false;
        }

        [HttpPost("bina-guncelle")]
        [Authorize]
        public bool UpdateBina(BinaUpdateRequest bina)
        {
            var binaResult = _binaService.GetById(bina.BinaId);
            if (binaResult != null)
            {
                binaResult.BinaAdi = bina.BinaAdi;
                binaResult.BinaAdresi = bina.BinaAdresi;

                _binaService.Update(binaResult);
                _binaService.Save();

                return true;
            }

            return false;
        }
    }
}