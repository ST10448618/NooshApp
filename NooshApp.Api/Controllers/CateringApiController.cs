using Microsoft.AspNetCore.Mvc;
using NooshApp.Api.Dtos;
using NooshApp.Api.Services.Interfaces;

namespace NooshApp.Api.Controllers
{
    [ApiController]
    [Route("api/catering")]
    public class CateringApiController : ControllerBase
    {
        private readonly ICateringService _cateringService;
        public CateringApiController(ICateringService cateringService) { _cateringService = cateringService; }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] CateringRequestCreateDto request)
        {
            var result = await _cateringService.SubmitRequestAsync(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _cateringService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }
    }
}