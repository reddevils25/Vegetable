using Microsoft.AspNetCore.Mvc;
using Vegetable.Models;
using Vegetable.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Vegetable.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly VegetablesContext _context;
        public LoginController(VegetablesContext context)
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

            // Kiểm tra ModelState trước
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            // Mã hóa mật khẩu
            string pw = Function.SHA256Password(user.Passwords);

            // Tìm tài khoản trong cơ sở dữ liệu
            var check = _context.AdminUsers
                                 .FirstOrDefault(m => m.Email == user.Email && m.Passwords == pw);

            if (check == null)
            {
                // Thông báo lỗi khi đăng nhập thất bại
                TempData["ErrorMessage"] = "Lỗi Tên Đăng Nhập hoặc Mật Khẩu";
                return RedirectToAction("Index", "Login");
            }

            // Lưu thông tin người dùng vào Function (hoặc session, cookie nếu cần)
            Function._Message = string.Empty;
            Function._UserId = check.UserId;
            Function._Username = string.IsNullOrEmpty(check.Username) ? string.Empty : check.Username;
            Function._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            Function._Role = check.Role;

            if (check != null)
            {
                if (check.Role) // Nếu Role là true (Admin)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else // Nếu Role là false (User)
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            else
            {
                // Xử lý khi không tìm thấy người dùng
                ModelState.AddModelError("", "Sai thông tin đăng nhập");
                return View();
            }
            
            //// Chuyển hướng người dùng đến trang chính của Admin
            //return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}
