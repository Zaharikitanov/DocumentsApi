using DocumentsApi.Database;
using DocumentsApi.Repository;
using DocumentsApi.Repository.Interfaces;
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
            builder.Services.AddScoped<IDocumentsRepository, DocumentsRepository>();

            //Used only for the initial start of the project
            //builder.Services.SetupDatabase(connection);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(options => options.WithOrigins("*").WithHeaders("*").AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}