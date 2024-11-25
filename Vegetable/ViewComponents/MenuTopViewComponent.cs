using Microsoft.AspNetCore.Mvc;
using Vegetable.Models;

namespace Vegetable.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly VegetablesContext _context;
        public MenuTopViewComponent(VegetablesContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.Menus
            .Where(m => m.IsActive == true) 
            .OrderBy(m => m.Position)
            .ToList();

            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
