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
        public async Task<IActionResult> Create(string name, string phone, string email, string message)
        {
            try
            {
                Contact contact = new Contact
                {
                    FullName = name,
                    Phone = phone,
                    EmailAddress = email,
                    InquiryMessage = message
                };

                _context.Add(contact);
                await _context.SaveChangesAsync(); 

                return Json(new { status = true });
            }
            catch (Exception ex)
            {  
                Console.WriteLine(ex.Message);
                return Json(new { status = false });
            }
        }

    }
}
