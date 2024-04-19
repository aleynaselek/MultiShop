using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin
{
    public class AdminLayoutController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
