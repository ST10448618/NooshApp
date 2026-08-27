using Microsoft.EntityFrameworkCore;
using NooshApp.Api.Data;
using NooshApp.Api.Models;
using NooshApp.Api.Repositories.Interfaces;

namespace NooshApp.Api.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuItemRepository(ApplicationDbContext context) { _context = context; }

        public async Task<List<MenuItem>> GetAllAsync() =>
            await _context.MenuItems.Where(m => m.IsAvailable)
                .OrderBy(m => m.Category).ThenBy(m => m.Name).ToListAsync();

        public async Task<List<MenuItem>> GetByCategoryAsync(string category) =>
            await _context.MenuItems.Where(m => m.IsAvailable && m.Category == category)
                .OrderBy(m => m.Name).ToListAsync();

        public async Task<List<MenuItem>> GetFeaturedAsync(int count)
        {
            var featuredItems = await _context.MenuItems
                .Where(m => m.IsAvailable && m.IsPopular).ToListAsync();
            return featuredItems.OrderBy(m => Guid.NewGuid()).Take(count).ToList();
        }
    }
}