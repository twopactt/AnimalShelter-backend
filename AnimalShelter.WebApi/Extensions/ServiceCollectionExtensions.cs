using AnimalShelter.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalShelter.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AnimalShelterDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(AnimalShelterDbContext)));
            });

            return services;
        }
    }
}