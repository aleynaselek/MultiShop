using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
       
		public UsersController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {             
            var userClaim = User.Claims.FirstOrDefault(x=>x.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByNameAsync(userClaim.Value);

            return Ok(new
            {
				Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Usrename = user.UserName
            } ); 
        }
    }
}
