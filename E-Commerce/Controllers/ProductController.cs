using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public ProductController(IProductService productService, ICommentService commentService)
        {
            _productService = productService;
            _commentService = commentService;
        }

        public IActionResult ProductList(int id)
        {
            Userinfo();
            if (id > 0)
            {
                var product = _productService.TGetProductByCategory(id);
                var categoryname = product.Select(x => x.Category.CategoryName).FirstOrDefault();
                ViewBag.Category = categoryname + " İlanları";
                return View(product);
            }
            else
            {
                ViewBag.Category = "Tüm İlanlar";
                var product = _productService.TGetList();
                return View(product);
            }
            
        }

        public IActionResult ProductDetails(int id)
        {
            Userinfo();
            var comments = _commentService.TGetListWithUser(id);           
            ViewBag.comment= comments;
            ViewBag.commentcount = comments.Count;
            ViewBag.Products = _productService.TGetList();
            var value=_productService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
            comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.UserID = userid;
            comment.Status = true;
            _commentService.TInsert(comment);
            return Json(new { SONUC = true });
        }

        public void Userinfo()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.mail = HttpContext.Session.GetString("mail");
            ViewBag.userid = HttpContext.Session.GetInt32("userid");
        }
    }
}
