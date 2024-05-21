using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.Concrete
{
	public class IdentityService : IIdentityService
    { 
        Task<bool> IIdentityService.SignIn(SignUpDto signUpDto)
        {
            throw new NotImplementedException();
        }
    }
}
