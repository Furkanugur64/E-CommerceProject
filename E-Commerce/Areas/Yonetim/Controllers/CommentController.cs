using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public CommentController(ICommentService commentService, IUserService userService, IProductService productService)
        {
            _commentService = commentService;
            _userService = userService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var comments = _commentService.TGetList(); // yorum listesini alma
            foreach (var comment in comments)
            {
                comment.User = _userService.TGetByID(comment.UserID);
                comment.Product = _productService.TGetByID(comment.ProductID);
            }
            return View(comments);
        }

        public IActionResult DetailComment(int id) 
        {
            var commentDetail = _commentService.TGetByID(id); 
            commentDetail.User = _userService.TGetByID(commentDetail.UserID);
            commentDetail.Product = _productService.TGetByID(commentDetail.ProductID);

            return View(commentDetail);
        }

        public IActionResult DeleteComment(int id) 
        {
            var comment = _commentService.TGetByID(id); 
            _commentService.TDelete(comment); 
            return RedirectToAction("Comment", "Yonetim");
        }
    }
}
