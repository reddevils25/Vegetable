using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vegetable.Models;

namespace Vegetable.Controllers
{
    public class ProductMainController : Controller
    {
        private readonly VegetablesContext _context;
        public ProductMainController(VegetablesContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Product = _context.Products.ToList();
            return View();
        }
    }
}
