using AnimalShelter.DataAccess;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Application.Services;
using AnimalShelter.DataAccess.Repositories;

namespace AnimalShelter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AnimalShelterDbContext>(
                options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AnimalShelterDbContext)));
                });

            // Services
            builder.Services.AddScoped<IAdoptionApplicationsService, AdoptionApplicationsService>();
            builder.Services.AddScoped<IAdoptionsService, AdoptionsService>();
            builder.Services.AddScoped<IAnimalsService, AnimalsService>();
            builder.Services.AddScoped<IAnimalStatusesService, AnimalStatusesService>();
            builder.Services.AddScoped<IEmployeesService, EmployeesService>();
            builder.Services.AddScoped<IRolesService, RolesService>();
            builder.Services.AddScoped<IStatusAdoptionsService, StatusAdoptionsService>();
            builder.Services.AddScoped<ITemporaryAccommodationsService, TemporaryAccommodationsService>();
            builder.Services.AddScoped<ITypeAnimalsService, TypeAnimalsService>();
            builder.Services.AddScoped<IUsersService, UsersService>();

            // Repositories
            builder.Services.AddScoped<IAdoptionApplicationsRepository, AdoptionApplicationsRepository>();
            builder.Services.AddScoped<IAdoptionsRepository, AdoptionsRepository>();
            builder.Services.AddScoped<IAnimalsRepository, AnimalsRepository>();
            builder.Services.AddScoped<IAnimalStatusesRepository, AnimalStatusesRepository>();
            builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            builder.Services.AddScoped<IRolesRepository, RolesRepository>();
            builder.Services.AddScoped<IStatusAdoptionsRepository, StatusAdoptionsRepository>();
            builder.Services.AddScoped<ITemporaryAccommodationsRepository, TemporaryAccommodationsRepository>();
            builder.Services.AddScoped<ITypeAnimalsRepository, TypeAnimalsRepository>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();


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

            app.UseCors(x =>
            {
                x.WithHeaders().AllowAnyHeader();
                x.WithOrigins("http://localhost:3000");
                x.WithMethods().AllowAnyMethod();
            });

            app.Run();
        }
    }
}