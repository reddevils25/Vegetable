using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vegetable.Models;

namespace Vegetable.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly VegetablesContext _context;

        public ProductViewComponent(VegetablesContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.Products.Include(m => m.Category).Where(m => m.IsNew == true);

            return await Task.FromResult<IViewComponentResult>
                (View(items.OrderByDescending(m => m.ProductId).ToList()));
        }
    }
}
