using DocumentsApi.Database;
using DocumentsApi.Database.Models;
using DocumentsApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocumentsApi.Repository
{
    public class DocumentsRepository : IDocumentsRepository
    {
        private readonly DocumentsApiContext _context;

        public DocumentsRepository(DocumentsApiContext context)
        {
            _context = context;
        }

        public Task<List<Document>> GetAllAsync()
        {
            return _context.Documents.ToListAsync();
        }

        public async Task<Document> CreateAsync(Document document)
        {
            await _context.AddAsync(document);
            await _context.SaveChangesAsync();

            return document;
        }
    }
}
