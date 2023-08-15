using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.ViewComponents.Default
{
    public class _MainOfferPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
