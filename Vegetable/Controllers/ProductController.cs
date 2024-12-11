using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vegetable.Models;

namespace Vegetable.Controllers
{
    public class ProductController : Controller
    {
        private readonly VegetablesContext _context;
        public ProductController(VegetablesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        [Route("/product/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(i => i.Category).FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.productReview = _context.ProductReviews.Where(i => i.ProductId == id && i.IsActive == true).ToList();
            ViewBag.productRelated = _context.Products.Where(i => i.ProductId != id && i.CategoryId == product.CategoryId).Take(5).OrderByDescending(i => i.ProductId).ToList();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, int ProductId, int rating, string message)
        {
            try
            {
                ProductReview productRv = new ProductReview
                {
                    Prname = name,
                    ProductId = ProductId,
                    Rating = rating,
                    Comment = message,
                     CreatedAt = DateTime.Now
                };

                _context.Add(productRv);
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
