using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class CategoryBrandController : Controller
    {

        private readonly Context _context;

        public CategoryBrandController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.Include(c => c.Brands).ToList();
            return View(categories);
        }

        public JsonResult GetBrandsForCategory(int categoryId)
        {
            var brands = _context.Brands
                .Where(brand => brand.CategoryID == categoryId)
                .ToList();

            return Json(brands);
        }
    }
}
