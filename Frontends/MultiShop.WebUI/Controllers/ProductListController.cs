using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.x = id;
            return View();
        } 
        
         
        public  PartialViewResult AddComment()
        { 
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(CreateCommentDto createCommentDto) 
        {
            return View();
                
        }
    }
}
