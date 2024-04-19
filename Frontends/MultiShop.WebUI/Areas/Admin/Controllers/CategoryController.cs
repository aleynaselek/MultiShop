using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            ViewBag.v1="Ana Sayfa";
            ViewBag.v2="Kategoriler";
            ViewBag.v3="Kategori Listesi";
            ViewBag.v0 = "Kategori İşlemleri";
            return View();
        }
    }
}
