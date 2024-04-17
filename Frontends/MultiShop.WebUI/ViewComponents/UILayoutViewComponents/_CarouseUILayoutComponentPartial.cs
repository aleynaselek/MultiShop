using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
	public class aaa : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
            return View();
        }
	 
	}
}
