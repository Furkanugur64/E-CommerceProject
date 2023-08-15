using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.ViewComponents.Default
{
    public class _MainBasketCount : ViewComponent
    {
        private readonly IBasketListService _basketListService;

        public _MainBasketCount(IBasketListService basketListService)
        {
            _basketListService = basketListService;
        }

        public IViewComponentResult Invoke()
        {
            int id =Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
            var values = _basketListService.TGetList();
            var count=values.Where(x => x.UserID == id).ToList();
            ViewBag.basketCount= count.Count;
            return View();
        }
    }
}
