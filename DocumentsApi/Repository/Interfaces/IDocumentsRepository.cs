using DocumentsApi.Database.Models;

namespace DocumentsApi.Repository.Interfaces
{
    public interface IDocumentsRepository
    {
        Task<List<Document>> GetAllAsync();

        Task<Document> CreateAsync(Document document);
    }
}