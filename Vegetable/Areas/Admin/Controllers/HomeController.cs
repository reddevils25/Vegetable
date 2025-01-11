using Microsoft.AspNetCore.Mvc;
using Vegetable.Utilities;

namespace Vegetable.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            if (!Function.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        //public ActionResult Logout()
        //{

        //    Function._UserId = 0;
        //    Function._Username = string.Empty;
        //    Function._Email = string.Empty;
        //    Function._Message = string.Empty;
        //    Function._MessageEmail = string.Empty;
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
