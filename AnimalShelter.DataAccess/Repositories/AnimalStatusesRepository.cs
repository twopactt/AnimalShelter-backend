using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.DataAccess.Repositories
{
    public class AnimalStatusesRepository : IAnimalStatusesRepository
    {
        private readonly AnimalShelterDbContext _context;

        public AnimalStatusesRepository(AnimalShelterDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnimalStatus>> Get()
        {
            var animalStatusEntities = await _context.AnimalStatus
                .AsNoTracking()
                .ToListAsync();

            var animalStatuses = animalStatusEntities
                .Select(b => AnimalStatus.Create(b.Id, b.Name).AnimalStatus)
                .ToList();

            return animalStatuses;
        }
    }
}