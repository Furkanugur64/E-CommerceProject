using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.ViewComponents.Default
{
    public class _MainCarouselPartial : ViewComponent
    {
        private readonly ICouponService _couponService;

        public _MainCarouselPartial(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _couponService.TGetList();
            var today = DateTime.Now.Date;
            var coupon = values
                .Where(x => x.Date.Date == today) 
                .Select(y => y.CouponCode)
                .FirstOrDefault(); 
            ViewBag.Coupon = coupon;
            return View();
        }
    }
}
