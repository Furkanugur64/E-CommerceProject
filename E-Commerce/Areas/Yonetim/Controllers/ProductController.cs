using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        
        private readonly Context _context;

        public ProductController(IProductService productService, Context context, ICategoryService categoryService, IBrandService brandService)
        {
            _productService = productService;
            _context = context;
            _categoryService = categoryService;
            _brandService = brandService;
        }


        public IActionResult Index()
        {
           // var values = _productService.TGetList();
            var values = _context.Products.Include(x=>x.Category).Include(y=>y.Brand).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {

            List<SelectListItem> valueCategory = (from x in _categoryService.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.categoryVlc = valueCategory;

            List<SelectListItem> valueBrand = (from x in _brandService.TGetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.BrandName,
                                                    Value = x.BrandID.ToString()
                                                }).ToList();
            ViewBag.brandVlc = valueBrand;

            return View();
        }


        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            product.Status = true;
            _productService.TInsert(product);
            return RedirectToAction("Product", "Yonetim");
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return RedirectToAction("Product", "Yonetim");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            //var value = _productService.TGetByID(id);
            List<SelectListItem> valueCategory = (from x in _categoryService.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.categoryVlc = valueCategory;

            List<SelectListItem> valueBrand = (from x in _brandService.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.BrandName,
                                                   Value = x.BrandID.ToString()
                                               }).ToList();
            ViewBag.brandVlc = valueBrand;
            var value = _productService.TGetByID(id);
            return View(value);
        }


        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            product.Status = true;
            _productService.TUpdate(product);
            return RedirectToAction("Product", "Yonetim");
        }

    }
}
