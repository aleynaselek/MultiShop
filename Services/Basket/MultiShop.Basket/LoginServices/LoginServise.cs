namespace MultiShop.Basket.LoginServices
{
    public class LoginServise: ILoginServise
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginServise(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
