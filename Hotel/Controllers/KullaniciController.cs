using Azure.Core;
using Azure;
using Hotel.Model.Request;
using Hotel.Model.ViewModel;
using Hotel.Service.Abstractions;
using Hotel.Service.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hotel.Model.Response;

namespace Hotel.Controllers
{
    [ApiController]
    [Route("kullanici")]
    public class KullaniciController : ControllerBase
    {
        private IKullaniciService _kullaniciService { get; set; }
        private ITokenService _tokenService { get; set; }

        public KullaniciController(IKullaniciService kullaniciService, ITokenService tokenService)
        {
            _kullaniciService = kullaniciService;
            _tokenService = tokenService;
        }

        [HttpPost(Name = "login")]
        [AllowAnonymous]
        public async Task<UserLoginResponse> Login(LoginViewModel model)
        {
            var kullanici = await _kullaniciService.Login(model.KullaniciAdi, model.Sifre);

            UserLoginResponse response = new();

            if (kullanici == null)
            {
                throw new ArgumentNullException(nameof(kullanici));
            }
            else
            {

                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { KullaniciAdi = kullanici.Adi });

                response.AuthenticateResult = true;
                response.AuthToken = generatedTokenInformation.Token;
                response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
            }

            return await Task.FromResult(response);
        }
    }
}