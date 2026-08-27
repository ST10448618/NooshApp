using Microsoft.AspNetCore.Mvc;
using NooshApp.Api.Dtos;
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
        [RequestSizeLimit(25 * 1024 * 1024)]
        public async Task<IActionResult> Apply([FromForm] CareerApplicationForm form)
        {
            var allowedExtensions = new[] { ".pdf", ".docx" };
            var extension = Path.GetExtension(form.CvFile.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
                return BadRequest(new { message = "Please upload a PDF or Word (.docx) file for your CV." });

            const int maxFileSizeBytes = 5 * 1024 * 1024;
            if (form.CvFile.Length > maxFileSizeBytes)
                return BadRequest(new { message = "CV file is too large. Maximum size is 5MB." });

            var result = await _careersService.SubmitApplicationAsync(
                form.FullName, form.PhoneNumber, form.Email, form.DesiredPosition,
                form.CoverLetter, form.CvFile, form.SupportingDocuments);

            return Ok(result);
        }
    }
}