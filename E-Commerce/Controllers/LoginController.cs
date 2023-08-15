using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
	public class LoginController : Controller
	{
        private readonly Context _contex;

        public LoginController(Context contex)
        {
            _contex = contex;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            var values = _contex.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);           
            if (values != null)
            {
                var userinfo = _contex.Users.Where(x => x.UserName == values.UserName).FirstOrDefault();
                HttpContext.Session.SetString("username", userinfo.UserName);
                HttpContext.Session.SetString("mail", userinfo.Mail);
                HttpContext.Session.SetInt32("userid", userinfo.UserID);
                return RedirectToAction("Index", "Default");

            }
            return RedirectToAction("Index", "Login");

        }
    }
}
