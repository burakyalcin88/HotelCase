using Hotel.Model.Entities;
using Hotel.Model.Request;
using Hotel.Service.Abstractions;
using Hotel.Service.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [ApiController]
    [Route("depo")]
    public class DepoController : ControllerBase
    {
        private IDepoService _depoService { get; set; }
        public DepoController(IDepoService depoService)
        {
            _depoService = depoService;
        }


        [HttpGet("depo-listesi")]
        [Authorize]
        public IEnumerable<Depo> GetDepoList()
        {
            return _depoService.GetAll();
        }


        [HttpPost("depo-ekle")]
        [Authorize]
        public bool AddDepo(DepoRequest depo)
        {
            var depoEntity = new Depo()
            {
                DepoAdi = depo.DepoAdi,
                BinaId = depo.BinaId,
                CreateTime = DateTime.Now
            };

            _depoService.Insert(depoEntity);
            _depoService.Save();

            return true;

        }

        [HttpPost("depo-sil")]
        [Authorize]
        public bool DeleteDepo(int depoId)
        {
            var depoResult = _depoService.GetById(depoId);

            if (depoResult != null)
            {
                depoResult.IsDeleted = true;
                depoResult.DeleteTime = DateTime.Now;

                _depoService.Save();

                return true;
            }
            else
                return false;
        }

        [HttpPost("depo-guncelle")]
        [Authorize]
        public bool UpdateDepo(DepoUpdateRequest depo)
        {
            var depoResult = _depoService.GetById(depo.DepoId);
            if (depoResult != null)
            {
                depoResult.DepoAdi = depo.DepoAdi;
                depoResult.BinaId = depo.BinaId;

                _depoService.Update(depoResult);
                _depoService.Save();

                return true;
            }

            return false;
        }





    }
}
