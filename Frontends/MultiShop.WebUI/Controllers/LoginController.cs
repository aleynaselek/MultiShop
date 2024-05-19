using Microsoft.AspNetCore.Mvc; 
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos; 
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        } 

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {   
            
				var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createLoginDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5001/api/Registers", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
            return View();

        }
    }
}
