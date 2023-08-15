using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace E_Commerce.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly Context _context;

        public AdminController(IAdminService adminService, Context context)
        {
            _adminService = adminService;
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _adminService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAdmin(Admin admin)
        {
            admin.Status = true;
            _adminService.TInsert(admin);
            return RedirectToAction("Admin", "Yonetim");
        }

        [HttpGet]
        public IActionResult UpdateAdmin(int id)
        {
            var value = _adminService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAdmin(Admin admin)
        {
            admin.Status = true;
            _adminService.TUpdate(admin);
            return RedirectToAction("Admin", "Yonetim");
        }

        public IActionResult DeleteAdmin(int id)
        {
            var value = _adminService.TGetByID(id);
            _adminService.TDelete(value);
            return RedirectToAction("Admin", "Yonetim");
        }

    }
}
