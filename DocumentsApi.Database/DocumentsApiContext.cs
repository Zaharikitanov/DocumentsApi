using DocumentsApi.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentsApi.Database
{
    public class DocumentsApiContext : DbContext
    {
        public DocumentsApiContext(DbContextOptions<DocumentsApiContext> context) : base(context)
        {

        }

        public DbSet<Document> Documents { get; set; }
    }
}