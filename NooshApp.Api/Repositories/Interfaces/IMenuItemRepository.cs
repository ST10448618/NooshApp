using NooshApp.Api.Models;

namespace NooshApp.Api.Repositories.Interfaces
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItem>> GetAllAsync();
        Task<List<MenuItem>> GetByCategoryAsync(string category);
        Task<List<MenuItem>> GetFeaturedAsync(int count);
        Task<List<MenuItem>> GetAllForAdminAsync();
        Task<MenuItem?> GetByIdAsync(int id);
        Task<MenuItem> CreateAsync(MenuItem item);
        Task UpdateAsync(MenuItem item);
        Task DeleteAsync(int id);
    }
}