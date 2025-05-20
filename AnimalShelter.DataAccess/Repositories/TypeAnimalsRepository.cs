using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.DataAccess.Repositories
{
    public class TypeAnimalsRepository : ITypeAnimalsRepository
    {
        private readonly AnimalShelterDbContext _context;

        public TypeAnimalsRepository(AnimalShelterDbContext context)
        {
            _context = context;
        }

        public async Task<List<TypeAnimal>> Get()
        {
            var typeAnimalEntities = await _context.TypeAnimal
                .AsNoTracking()
                .ToListAsync();

            var typeAnimals = typeAnimalEntities
                .Select(b => TypeAnimal.Create(b.Id, b.Name).TypeAnimal)
                .ToList();

            return typeAnimals;
        }
    }
}