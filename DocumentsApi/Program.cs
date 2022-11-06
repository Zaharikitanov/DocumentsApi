using DocumentsApi.Database;
using DocumentsApi.Services;
using DocumentsApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocumentsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, true)
                .AddEnvironmentVariables();

            var connection = builder.Configuration.GetConnectionString("Documents");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DocumentsApiContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("DocumentsApi.Database")));
            builder.Services.AddScoped<IDocumentsService, DocumentsService>();

            var optionsBuilder = new DbContextOptionsBuilder<DocumentsApiContext>();
            optionsBuilder.UseSqlServer(connection);

            var db = new DocumentsApiContext(optionsBuilder.Options);
            db.Database.EnsureDeleted();
            db.Database.Migrate();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}