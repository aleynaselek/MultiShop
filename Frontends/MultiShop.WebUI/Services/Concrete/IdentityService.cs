using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;
using Microsoft.Extensions.Options;
using IdentityModel.Client;

namespace MultiShop.WebUI.Services.Concrete
{
	public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;
        private readonly ClientSettings _clientSettings; 

        public IdentityService(IHttpContextAccessor httpContextAccessor, HttpClient httpClient, IOptions<ClientSettings> clientSettings) 
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            _clientSettings = clientSettings.Value;
        }

        public async Task<bool> SignIn(SignUpDto signUpDto)
        {
            var dicoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address= "http://localhost:5001",
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false,
                }
            });

            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                UserName = signUpDto.Username,
                Password = signUpDto.Password,
                Address = dicoveryEndPoint.TokenEndpoint
            };



            return 
        }
    }
}
