using Microsoft.AspNetCore.Mvc;
using NooshApp.Api.Services.Interfaces;

namespace NooshApp.Api.Controllers
{
    [ApiController]
    [Route("api/menu")]
    public class MenuApiController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuApiController(IMenuService menuService) { _menuService = menuService; }

        [HttpGet("featured")]
        public async Task<IActionResult> GetFeatured() =>
            Ok(await _menuService.GetFeaturedMealsAsync());

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _menuService.GetFullMenuAsync());

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategory(string category) =>
            Ok(await _menuService.GetMenuByCategoryAsync(category));
    }
}