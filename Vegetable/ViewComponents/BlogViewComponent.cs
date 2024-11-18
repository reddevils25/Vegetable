using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vegetable.Models;

namespace Vegetable.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly VegetablesContext _context;
        public BlogViewComponent(VegetablesContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.Blogs.Include(m => m.Category).Where(m => m.IsActive == true);

            return await Task.FromResult<IViewComponentResult>
                (View(items.OrderByDescending(m => m.BlogId).ToList()));
        }
    }
}
