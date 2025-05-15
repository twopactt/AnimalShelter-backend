using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Repositories
{
    public interface IRolesRepository
    {
        Task<List<Role>> Get();
    }
}