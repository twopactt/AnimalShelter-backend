using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.DataAccess.Repositories
{
    public class StatusTemporaryAccommodationsRepository : IStatusTemporaryAccommodationsRepository
    {
        private readonly AnimalShelterDbContext _context;

        public StatusTemporaryAccommodationsRepository(AnimalShelterDbContext context)
        {
            _context = context;
        }

        public async Task<List<StatusTemporaryAccommodation>> Get()
        {
            var statusTemporaryAccommodationEntities = await _context.StatusTemporaryAccommodation
                .AsNoTracking()
                .ToListAsync();

            var statusTemporaryAccommodations = statusTemporaryAccommodationEntities
                .Select(b => StatusTemporaryAccommodation.Create(b.Id, b.Name).StatusTemporaryAccommodation)
                .ToList();

            return statusTemporaryAccommodations;
        }
    }
}