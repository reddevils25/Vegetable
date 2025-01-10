using Microsoft.AspNetCore.Mvc;
using Vegetable.Models;
using Vegetable.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Vegetable.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly VegetablesContext _context;

        public RegisterController(VegetablesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminUser user)
        {
            if (user == null)
            {
                return NotFound();
            }

            // Kiểm tra email hoặc username đã tồn tại chưa
            var check = _context.AdminUsers
                .Where(m => m.Email == user.Email || m.Username == user.Username)
                .FirstOrDefault();

            if (check != null)
            {
                // Kiểm tra xem email hay username đã tồn tại
                if (check.Email == user.Email)
                {
                    ModelState.AddModelError("Email", "Email đã được sử dụng!");
                }
                else if (check.Username == user.Username)
                {
                    ModelState.AddModelError("Username", "Username đã được sử dụng!");
                }

                return View(user); // Trả lại trang đăng ký với thông báo lỗi
            }

            if (ModelState.IsValid)
            {
                user.Role = false;
                // Mã hóa mật khẩu sử dụng SHA-256 (hoặc bạn có thể chọn bcrypt)
                user.Passwords = Function.SHA256Password(user.Passwords); // Thay đổi hàm hash ở đây     
                _context.Add(user);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Đăng ký thành công. Vui lòng đăng nhập!";
                return RedirectToAction("Index", "Login"); // Điều hướng đến trang đăng nhập
            }

            return View(user); // Trả lại trang đăng ký nếu dữ liệu không hợp lệ
        }
    }
}
