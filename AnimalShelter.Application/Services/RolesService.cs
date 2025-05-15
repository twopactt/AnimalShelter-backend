using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Repositories;

namespace AnimalShelter.Application.Services
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesService(IRolesRepository roleRepository)
        {
            _rolesRepository = roleRepository;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _rolesRepository.Get();
        }
    }
}