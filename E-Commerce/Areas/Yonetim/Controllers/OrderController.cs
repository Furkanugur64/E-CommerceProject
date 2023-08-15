using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService, IUserService userService, IProductService productService)
        {
            _orderService = orderService;
            _userService = userService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var value = _orderService.TGetList();
            foreach (var comment in value)
            {
                comment.User = _userService.TGetByID(comment.UserID);
                comment.Product = _productService.TGetByID(comment.ProductID);
            }
            return View(value);
        }

        public IActionResult DetailOrder(int id)
        {
            var value = _orderService.TGetByID(id);
            value.User = _userService.TGetByID(value.UserID);
            value.Product = _productService.TGetByID(value.ProductID);
            return View(value);
        }

        public IActionResult DeleteOrder(int id)
        {
            var value = _orderService.TGetByID(id);
            _orderService.TDelete(value);
            return RedirectToAction("Order", "Yonetim");
        }
    }
}
