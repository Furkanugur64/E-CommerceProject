using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete; // Gerekli using ifadelerini ekleyin
using BusinessLayer.Abstract;

namespace E_Commerce.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;

        public LoginController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Admin model)
        {
            var values = _adminService.TGetList();
            var admin = values.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            if (admin != null)
            {
                return RedirectToAction("Category", "Yonetim");
            }

            return RedirectToAction("Login", "Yonetim");

        }

    }
}

