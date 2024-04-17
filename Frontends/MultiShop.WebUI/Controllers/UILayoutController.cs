using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Models;
using System.Diagnostics;

namespace MultiShop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
         
        public IActionResult _UILayout()
        {
            return View();
        }

       
    }
}
