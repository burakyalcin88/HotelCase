using Hotel.Model.Entities;
using Hotel.Service.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return _binaService.GetAll();
        }
    }
}
