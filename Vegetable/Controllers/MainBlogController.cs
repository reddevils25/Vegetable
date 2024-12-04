using Microsoft.AspNetCore.Mvc;

namespace Vegetable.Controllers
{
    public class MainBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
