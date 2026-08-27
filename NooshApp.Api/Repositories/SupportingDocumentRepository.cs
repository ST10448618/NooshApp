using NooshApp.Api.Data;
using NooshApp.Api.Models;
using NooshApp.Api.Repositories.Interfaces;

namespace NooshApp.Api.Repositories
{
    public class SupportingDocumentRepository : ISupportingDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        public SupportingDocumentRepository(ApplicationDbContext context) { _context = context; }

        public async Task AddRangeAsync(List<SupportingDocument> documents)
        {
            await _context.SupportingDocuments.AddRangeAsync(documents);
            await _context.SaveChangesAsync();
        }
    }
}