using Microsoft.AspNetCore.Mvc;

namespace Vegetable.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password, bool RememberMe)
        {
            // Giả lập kiểm tra thông tin đăng nhập
            if (Username == "admin" && Password == "12345")
            {
                // Đăng nhập thành công
                HttpContext.Session.SetString("AdminUsername", Username);
                return RedirectToAction("Index");
            }

            // Đăng nhập thất bại
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }
    }
}
