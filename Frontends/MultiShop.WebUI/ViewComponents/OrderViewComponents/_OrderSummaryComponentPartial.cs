using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;
        public _OrderSummaryComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasket();
            var basketItems = basketTotal.BasketItems;
            var tax = basketTotal.TotalPrice / 10;
            var totalPriceWithTax = basketTotal.TotalPrice + tax;
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            return View(basketItems);
        }
    }
}
