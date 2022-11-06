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
                         new Document { DocumentName = "document_instructions", FileName = "document_instructions.docx", FileSize = 2097152 },
                         new Document { DocumentName = "advanced_javascript_practices", FileName = "advanced_javascript_practices.pdf", FileSize = 12097152 },
                         new Document { DocumentName = "C# 8.0 and .NET Core 3.0", FileName = "C# 8.0 and .NET Core 3.0.docx", FileSize = 22097152 },
                         new Document { DocumentName = "C# in Depth", FileName = "C# in Depth.pdf", FileSize = 32097152 });
        }

        public DbSet<Document> Documents { get; set; }
    }
}