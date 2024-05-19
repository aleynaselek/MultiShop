﻿using Microsoft.AspNetCore.Mvc; 
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
            var content = new StringContent(JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("http://localhost:5001/api/Logins", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if(tokenModel != null) 
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();
                }


			}
        return View();

        }
    }
}
