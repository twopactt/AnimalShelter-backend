using AnimalShelter.Application.Extensions;
using AnimalShelter.DataAccess.Extensions;
using AnimalShelter.WebApi.Extensions;
using Microsoft.Extensions.FileProviders;

namespace AnimalShelter.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            builder.Services
                .AddInfrastructure(builder.Configuration)
                .AddDataAccess()
                .AddApplication();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(x =>
            {
                x.WithHeaders().AllowAnyHeader();
                x.WithOrigins("http://localhost:3000");
                x.WithMethods().AllowAnyMethod();
            });

            app.UseAuthorization();

            var uploadsPath = Path.Combine(builder.Environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(uploadsPath),
                RequestPath = "/uploads"
            });

            app.MapControllers();

            app.Run();
        }
    }
}