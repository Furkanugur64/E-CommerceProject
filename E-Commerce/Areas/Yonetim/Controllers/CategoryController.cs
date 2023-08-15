using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var values = _categoryService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.Status = true;
            _categoryService.TInsert(category);
            return RedirectToAction("Category", "Yonetim");
        }
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            value.Status = false;
            _categoryService.TDelete(value);
            return RedirectToAction("Category", "Yonetim");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            category.Status = true;
            _categoryService.TUpdate(category);
            return RedirectToAction("Category", "Yonetim");
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
