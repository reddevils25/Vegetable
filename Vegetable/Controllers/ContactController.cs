using Microsoft.AspNetCore.Mvc;
using Vegetable.Models;

namespace Vegetable.Controllers
{
    public class ContactController : Controller
    {

        private readonly VegetablesContext _context;
        public ContactController(VegetablesContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, string phone, string email, string message)
        {
            try
            {
                Contact contact = new Contact();
                contact.FullName = name;
                contact.Phone = phone;
                contact.EmailAddress = email;
                contact.InquiryMessage = message;
                contact.CreatedOn = DateTime.Now;
                _context.Add(contact);
                _context.SaveChangesAsync();

                return Json(new { status = true });

            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
