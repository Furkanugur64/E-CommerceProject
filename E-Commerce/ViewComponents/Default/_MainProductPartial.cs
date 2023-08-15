using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.ViewComponents.Default
{
    public class _MainProductPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _MainProductPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var values =_productService.TGetList();
            return View(values);
        }
    }
}
