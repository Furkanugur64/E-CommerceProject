using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.TGetList();
            return View(users);
        }

        public IActionResult DeleteUser(int id)
        {
            var value = _userService.TGetByID(id);
            _userService.TDelete(value);
            return RedirectToAction("User", "Yonetim");
        }
    }
}
