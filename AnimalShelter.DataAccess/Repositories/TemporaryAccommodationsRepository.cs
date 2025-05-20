using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.DataAccess.Repositories
{
    public class TemporaryAccommodationsRepository : ITemporaryAccommodationsRepository
    {
        private readonly AnimalShelterDbContext _context;

        public TemporaryAccommodationsRepository(AnimalShelterDbContext context)
        {
            _context = context;
        }

        public async Task<List<TemporaryAccommodation>> Get()
        {
            var temporaryAccommodationEntities = await _context.TemporaryAccommodation
                .AsNoTracking()
                .ToListAsync();

            var temporaryAccommodations = temporaryAccommodationEntities
                .Select(b => TemporaryAccommodation.Create(b.Id, b.DateAnimalCapture, b.DateAnimalReturn, b.UserId, b.AnimalId).TemporaryAccommodation)
                .ToList();

            return temporaryAccommodations;
        }

        public async Task<Guid> Create(TemporaryAccommodation temporaryAccommodation)
        {
            var temporaryAccommodationEntity = new TemporaryAccommodationEntity
            {
                Id = temporaryAccommodation.Id,
                DateAnimalCapture = temporaryAccommodation.DateAnimalCapture,
                DateAnimalReturn = temporaryAccommodation.DateAnimalReturn,
                UserId = temporaryAccommodation.UserId,
                AnimalId = temporaryAccommodation.AnimalId
            };

            await _context.TemporaryAccommodation.AddAsync(temporaryAccommodationEntity);
            await _context.SaveChangesAsync();

            return temporaryAccommodationEntity.Id;
        }

        public async Task<Guid> Update(
            Guid id,
            DateOnly dateAnimalCapture,
            DateOnly dateAnimalReturn,
            Guid userId,
            Guid animalId)
        {
            await _context.TemporaryAccommodation
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.DateAnimalCapture, b => dateAnimalCapture)
                    .SetProperty(b => b.DateAnimalReturn, b => dateAnimalReturn)
                    .SetProperty(b => b.UserId, b => userId)
                    .SetProperty(b => b.AnimalId, b => animalId));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.TemporaryAccommodation
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}