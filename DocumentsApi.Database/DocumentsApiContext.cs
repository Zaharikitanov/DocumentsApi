using DocumentsApi.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentsApi.Database
{
    public class DocumentsApiContext : DbContext
    {
        public DocumentsApiContext(DbContextOptions<DocumentsApiContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                        .HasData(
                         new Document { Id = new Guid("19dd725d-d032-413b-bd04-ca89e5c8394b"), DocumentName = "document_instructions", FileName = "document_instructions.docx", FileSize = 2097152 },
                         new Document { Id = new Guid("42069b65-489e-4aea-bc8d-320acad1c17b"), DocumentName = "advanced_javascript_practices", FileName = "advanced_javascript_practices.pdf", FileSize = 12097152 },
                         new Document { Id = new Guid("8770e755-ea68-4995-8553-a0b49e4f46ba"), DocumentName = "C# 8.0 and .NET Core 3.0", FileName = "C# 8.0 and .NET Core 3.0.docx", FileSize = 22097152 },
                         new Document { Id = new Guid("feac3b11-5269-4678-b656-d4fda7c6a889"), DocumentName = "C# in Depth", FileName = "C# in Depth.pdf", FileSize = 32097152 });
        }

        public DbSet<Document> Documents { get; set; }
    }
}