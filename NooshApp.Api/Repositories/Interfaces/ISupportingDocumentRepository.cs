using NooshApp.Api.Models;

namespace NooshApp.Api.Repositories.Interfaces
{
    public interface ISupportingDocumentRepository
    {
        Task AddRangeAsync(List<SupportingDocument> documents);
    }
}