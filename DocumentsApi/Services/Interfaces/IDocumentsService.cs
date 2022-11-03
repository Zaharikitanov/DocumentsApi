using DocumentsApi.Database.Models;

namespace DocumentsApi.Services.Interfaces
{
    public interface IDocumentsService
    {
        Task<List<Document>> GetAllAsync();
    }
}