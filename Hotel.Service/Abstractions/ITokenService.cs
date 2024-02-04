using Hotel.Model.Request;
using Hotel.Model.Response;

namespace Hotel.Service.Abstractions
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
    }
}