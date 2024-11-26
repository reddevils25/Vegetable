using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vegetable.Models;

namespace Vegetable.Controllers
{
    public class BlogController : Controller
    {
        private readonly VegetablesContext _context;
        public BlogController(VegetablesContext context)
        {
            _context = context;
        }
        [Route("/blog/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Blogs == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }

            ViewBag.blogComment = _context.BlogComments.Where(i => i.BlogId == id).ToList();
            ViewBag.blog = _context.Blogs.ToList();
            return View(blog);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
