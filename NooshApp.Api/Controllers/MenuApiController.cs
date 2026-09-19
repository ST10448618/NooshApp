using Microsoft.AspNetCore.Mvc;
using NooshApp.Api.Dtos;
using NooshApp.Api.Services.Interfaces;

namespace NooshApp.Api.Controllers
{
    [ApiController]
    [Route("api/menu")]
    public class MenuApiController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IAdminService _adminService;
        public MenuApiController(IMenuService menuService, IAdminService adminService)
        {
            _menuService = menuService;
            _adminService = adminService;
        }

        [HttpGet("featured")]
        public async Task<IActionResult> GetFeatured() =>
            Ok(await _menuService.GetFeaturedMealsAsync());

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _menuService.GetFullMenuAsync());

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategory(string category) =>
            Ok(await _menuService.GetMenuByCategoryAsync(category));
        
        [HttpGet("menu-items")]
        public async Task<IActionResult> GetAllMenuItems()
        {
            var items = await _adminService.GetAllMenuItemsAsync();
            return Ok(items.Select(ToAdminDto));
        }

        [HttpPost("menu-items")]
        public async Task<IActionResult> CreateMenuItem([FromBody] CreateMenuItemRequestDto request)
        {
            var item = await _adminService.CreateMenuItemAsync(request);
            return Ok(ToAdminDto(item));
        }

        [HttpPut("menu-items/{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, [FromBody] UpdateMenuItemRequestDto request)
        {
            var item = await _adminService.UpdateMenuItemAsync(id, request);
            return item == null ? NotFound() : Ok(ToAdminDto(item));
        }

        [HttpDelete("menu-items/{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            await _adminService.DeleteMenuItemAsync(id);
            return Ok(new { message = "Menu item deleted." });
        }

        [HttpPost("menu-items/{id}/image")]
        public async Task<IActionResult> UploadMenuItemImage(int id, IFormFile image)
        {
            var imageUrl = await _adminService.UploadMenuItemImageAsync(id, image);
            return imageUrl == null
                ? BadRequest(new { message = "Invalid image (must be JPG/PNG, max 5MB) or item not found." })
                : Ok(new { imageUrl });
        }

        private static NooshApp.Api.Dtos.MenuItemAdminDto ToAdminDto(NooshApp.Api.Models.MenuItem item) => new()
        {
            Id = item.Id, Name = item.Name, Description = item.Description, Price = item.Price,
            Category = item.Category, ImageUrl = item.ImageUrl, IsPopular = item.IsPopular,
            IsVegetarian = item.IsVegetarian, SpiceLevel = (int)item.SpiceLevel,
            ContainsEggs = item.ContainsEggs, ContainsWheat = item.ContainsWheat,
            ContainsDairy = item.ContainsDairy, ContainsSesame = item.ContainsSesame,
            IsAvailable = item.IsAvailable
        };
    }
}