using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.ViewComponents.Default
{
    public class _NavbarCategoryPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _NavbarCategoryPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetList();
            return View(values);
        }
    }
}
