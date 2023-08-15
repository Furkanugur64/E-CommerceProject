using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace E_Commerce.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        private readonly Context _context;
        public BrandController(IBrandService brandService, Context context, ICategoryService categoryService)
        {
            _brandService = brandService;
            _context = context;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            //var values = _brandService.TGetList();
            var values = _context.Brands.Include(x => x.Category).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBrand()
        {
            List<SelectListItem> valueCategory = (from x in _categoryService.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.categoryVlc = valueCategory;
            return View();
        }
        [HttpPost]
        public IActionResult AddBrand(Brand brand)
        {
            brand.Status = true;
            _brandService.TInsert(brand);
            return RedirectToAction("Brand","Yonetim");
        }
        public IActionResult DeleteBrand(int id)
        {
            var value = _brandService.TGetByID(id);
            value.Status = false;
            _brandService.TDelete(value);
            return RedirectToAction("Brand", "Yonetim");
        }
        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            List<SelectListItem> valueCategory = (from x in _categoryService.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.categoryVlc = valueCategory;
            var value = _brandService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateBrand(Brand brand)
        {
            brand.Status = true;
            _brandService.TUpdate(brand);
            return RedirectToAction("Brand", "Yonetim");
        }
    }
}
