using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpPost]
        public IActionResult CheckCoupon(string couponCode)
        {
            var x =_couponService.TCheckCoupon(couponCode);
            if (x == "uygunkupon")
            {
                return Json(new { uygun = true });
            }
            else if (x == "tarihigeçmiş")
            {
                return Json(new { sonuc = true });
            }
            else 
            {
                return Json(new { sonuc = false });
            }           
        }
    }
}
