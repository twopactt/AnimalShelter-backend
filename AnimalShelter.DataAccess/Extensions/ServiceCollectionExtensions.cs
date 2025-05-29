using AnimalShelter.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalShelter.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IAdoptionApplicationsRepository, AdoptionApplicationsRepository>();
            services.AddScoped<IAdoptionsRepository, AdoptionsRepository>();
            services.AddScoped<IAnimalsRepository, AnimalsRepository>();
            services.AddScoped<IAnimalStatusesRepository, AnimalStatusesRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IStatusAdoptionsRepository, StatusAdoptionsRepository>();
            services.AddScoped<ITemporaryAccommodationsRepository, TemporaryAccommodationsRepository>();
            services.AddScoped<ITypeAnimalsRepository, TypeAnimalsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}