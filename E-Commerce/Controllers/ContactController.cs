using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.mail = HttpContext.Session.GetString("mail");
            ViewBag.userid = HttpContext.Session.GetInt32("userid");
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            int userid =Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
            contact.UserID = userid;
            contact.CreatedDate= DateTime.Now;
            _contactService.TInsert(contact);
            return Json(new { SONUC = true });
        }
    }
}
