using IdentityServer4.Hosting.LocalApiAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{ 
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginsController(SignInManager<IdentityUser> signInManager)
        {
			_signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
             
            var result =  await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password,false,false);
            if (result.Succeeded)
            {
                return Ok("Giriş başarılı.");
            }
            else
            {
                return Ok("Kullanıcı Adı veya Şifre Hatalı");
            }
        }
    }
}
