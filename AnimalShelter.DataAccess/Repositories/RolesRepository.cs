using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.DataAccess.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly AnimalShelterDbContext _context;

        public RolesRepository(AnimalShelterDbContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> Get()
        {
            var roleEntities = await _context.Role
                .AsNoTracking()
                .ToListAsync();

            var roles = roleEntities
                .Select(b => Role.Create(b.Id, b.Name).Role)
                .ToList();

            return roles;
        }
    }
}