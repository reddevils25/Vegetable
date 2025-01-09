using Microsoft.AspNetCore.Mvc;

namespace Vegetable.Areas.Admin.Controllers
{
    public class FileManagerController : Controller
    {
        [Area("Admin")]
        [Route("/Admin/file-manager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
