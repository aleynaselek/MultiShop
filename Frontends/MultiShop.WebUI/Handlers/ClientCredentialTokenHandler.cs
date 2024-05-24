using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net;

namespace MultiShop.WebUI.Handlers
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokenService;
        private readonly IIdentityService _identityService;

        
        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService, IIdentityService identityService)
        {
            _identityService = identityService;
            _clientCredentialTokenService = clientCredentialTokenService;

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
             
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",await _clientCredentialTokenService.GetToken());
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var tokenResponse = await _identityService.GetRefreshToken();
                if (tokenResponse != null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    response = await base.SendAsync(request, cancellationToken);
                }
            }
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //hata mesajı
            }
            return response;
        }
    }
}
