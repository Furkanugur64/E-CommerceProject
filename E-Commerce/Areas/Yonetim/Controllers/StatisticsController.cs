using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Areas.Yonetim.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
