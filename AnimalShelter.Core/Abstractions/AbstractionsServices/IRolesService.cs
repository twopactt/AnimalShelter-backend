using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface IRolesService
    {
        Task<List<Role>> GetAllRoles();
    }
}