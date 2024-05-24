using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services
{
	public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
