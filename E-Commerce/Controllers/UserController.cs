using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public UserController(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult MyAccount()
        {
            
            int id=Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
            var user=_userService.TGetByID(id);
            Userinfo();
            return View(user);
        }

        [HttpPost]
        public IActionResult MyAccount(User user)
        {           
            var userinfo = _userService.TGetByID(user.UserID);
            userinfo.UserName = user.UserName;
            userinfo.Password = user.Password;
            userinfo.Name = user.Name;
            userinfo.Surname = user.Surname;
            userinfo.Mail = user.Mail;
            userinfo.PhoneNumber = user.PhoneNumber;
            _userService.TUpdate(userinfo);
            Userinfo();
            return RedirectToAction("Index", "Default");
        }

        public IActionResult MyOrders()
        {            
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
            var order = _orderService.TGetOrderByUser(id);
            Userinfo();
            return View(order);
        }

        public void Userinfo()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.mail = HttpContext.Session.GetString("mail");
            ViewBag.userid = HttpContext.Session.GetInt32("userid");
        }

        
    }
}
