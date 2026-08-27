using NooshApp.Api.Models;

namespace NooshApp.Api.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendCareerApplicationNotificationAsync(JobApplication application, List<string> attachmentPaths);
    }
}