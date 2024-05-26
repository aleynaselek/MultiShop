namespace MultiShop.Basket.Dtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }

        public List<BasketItemDto> BasketItems { get; set; }
        public decimal? TotalPrice
        {
            get
            {
                if (BasketItems == null || !BasketItems.Any())
                {
                    return null; // Return null for empty basket
                }

                return BasketItems.Sum(x => x.Price * x.Quantity);
            }
            set  {   }
        }
    }
}
