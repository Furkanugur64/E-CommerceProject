using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IUserService _userService;

		public RegisterController(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(User user)
		{
			user.Status = true;
			_userService.TInsert(user);
			return RedirectToAction("Index", "Login");
		}
	}
}
