using BusinessLayer.Abstract;
using E_Commerce.Models.Dtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketListService _basketListService;
        private readonly IOrderService _orderService;

        public BasketController(IBasketListService basketListService, IOrderService orderService)
        {
            _basketListService = basketListService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
            var values = _basketListService.TGetBasketWithProduct(userid);
            int sumPrice = _basketListService.TBasketSumPrice(userid);
            ViewBag.totalPrice=sumPrice;
            return View(values);
        }

        public IActionResult Checkout(int price)
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
            var values = _basketListService.TGetBasketWithProduct(userid);
            ViewBag.price = price;
            return View(values);
        }

        [HttpPost]
        public IActionResult AddBasket(BasketList basketList)
        {
            int userid =Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
            if (_basketListService.TBasketControl(basketList.ProductID,userid))
            {
                basketList.ProductCount = 1;
                basketList.UserID = userid;
                _basketListService.TInsert(basketList);
                return Json(new { SONUC = true });
            }
            else
            {
                return Json(new { SONUC = false });
            }          
        }

        [HttpPost]
        public IActionResult UpdateBasket(UpdateBasketDto updateBasketDto)
        {
            if (updateBasketDto.Operation == "Update")
            {
                _basketListService.TUpdateCount(updateBasketDto.basketid, updateBasketDto.count);
                return Json(new { SONUC = true });
            }
            else if (updateBasketDto.Operation == "Delete")
            {
                _basketListService.TDeleteBasket(updateBasketDto.basketid);
                return Json(new { SONUC = true });
            }
            return Json(new { SONUC = false });
        }

        public IActionResult CardControl(string cardNumber)
        {
            var result=_basketListService.TCardNumberControl(cardNumber);
            return Json(new { SONUC = result });
        }


        public IActionResult AddOrder(int totalPrice)
        {
            var values = _basketListService.TGetList();
            int userid = Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
            foreach (var item in values)
            {
                Order order = new Order
                {
                    OrderDate = DateTime.Now,
                    ProductID= item.ProductID,
                    OrderStatus="Hazırlanıyor",
                    ProductCount= item.ProductCount,
                    Status=true,
                    TotalPrice= totalPrice,
                    UserID= userid,   
                    Address="yok"
                };
                _orderService.TInsert(order);
            }
            _basketListService.TDeleteBaskets(userid);
            return Json(new { SONUC = true });
        }
        
        
    }
}
