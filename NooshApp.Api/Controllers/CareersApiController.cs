using Microsoft.AspNetCore.Mvc;
using NooshApp.Api.Services.Interfaces;

namespace NooshApp.Api.Controllers
{
    [ApiController]
    [Route("api/careers")]
    public class CareersApiController : ControllerBase
    {
        private readonly ICareersService _careersService;
        public CareersApiController(ICareersService careersService) { _careersService = careersService; }

        [HttpPost("apply")]
        [RequestSizeLimit(25 * 1024 * 1024)] // raised to accommodate CV + up to 3 supporting docs
        public async Task<IActionResult> Apply(
            [FromForm] string fullName,
            [FromForm] string phoneNumber,
            [FromForm] string email,
            [FromForm] string desiredPosition,
            [FromForm] string? coverLetter,
            [FromForm] IFormFile cvFile,
            [FromForm] List<IFormFile>? supportingDocuments)
        {
            var allowedExtensions = new[] { ".pdf", ".docx" };
            var extension = Path.GetExtension(cvFile.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
                return BadRequest(new { message = "Please upload a PDF or Word (.docx) file for your CV." });

            const int maxFileSizeBytes = 5 * 1024 * 1024;
            if (cvFile.Length > maxFileSizeBytes)
                return BadRequest(new { message = "CV file is too large. Maximum size is 5MB." });

            var result = await _careersService.SubmitApplicationAsync(
                fullName, phoneNumber, email, desiredPosition, coverLetter, cvFile, supportingDocuments);

            return Ok(result);
        }
    }
}