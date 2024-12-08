using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vegetable.Models;

namespace Vegetable.Controllers
{
    public class CartController : Controller
    {
        private readonly VegetablesContext _context;

        public CartController(VegetablesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            var cartId = 1;

            var cartItems = _context.CartItems
                .Where(c => c.CartId == cartId).Include(c => c.Product) 
                .ToList();

            var total = cartItems.Sum(c => c.Quantity * c.Product.Price);

            
            ViewBag.Total = total;
            return View(cartItems); 
        }
    }

}
