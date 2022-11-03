using DocumentsApi.Database;
using DocumentsApi.Database.Models;
using DocumentsApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocumentsApi.Services
{
    public class DocumentsService : IDocumentsService
    {
        private readonly DocumentsApiContext _context;

        public DocumentsService(DocumentsApiContext context)
        {
            _context = context;
        }

        public async Task<List<Document>> GetAllAsync()
        {
            return await _context.Documents.ToListAsync();
        }
    }
}
