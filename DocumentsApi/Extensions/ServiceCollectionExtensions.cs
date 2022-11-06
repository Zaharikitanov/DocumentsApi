using DocumentsApi.Database;
using Microsoft.EntityFrameworkCore;

namespace DocumentsApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void SetupDatabase(this IServiceCollection services, string connection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DocumentsApiContext>();
            optionsBuilder.UseSqlServer(connection);

            var db = new DocumentsApiContext(optionsBuilder.Options);
            db.Database.EnsureDeleted();
            db.Database.Migrate();
        }
    }
}
