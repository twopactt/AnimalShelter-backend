using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AnimalShelter.DataAccess.Repositories
{
    public class AdoptionsRepository : IAdoptionsRepository
    {
        private readonly AnimalShelterDbContext _context;

        public AdoptionsRepository(AnimalShelterDbContext context)
        {
            _context = context;
        }

        public async Task<List<Adoption>> Get()
        {
            var adoptionEntities = await _context.Adoption
                .AsNoTracking()
                .ToListAsync();

            var adoptions = adoptionEntities
                .Select(b => Adoption.Create(b.Id, b.ApplicationDate, b.UserId, b.AnimalId).Adoption)
                .ToList();

            return adoptions;
        }

        public async Task<Guid> Create(Adoption adoption)
        {
            var adoptionEntity = new AdoptionEntity
            {
                Id = adoption.Id,
                ApplicationDate = adoption.ApplicationDate,
                UserId = adoption.UserId,
                AnimalId = adoption.AnimalId
            };

            await _context.Adoption.AddAsync(adoptionEntity);
            await _context.SaveChangesAsync();

            return adoptionEntity.Id;
        }

        public async Task<Guid> Update(
            Guid id,
            DateOnly applicationDate,
            Guid userId,
            Guid animalId)
        {
            await _context.Adoption
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.ApplicationDate, b => applicationDate)
                    .SetProperty(b => b.UserId, b => userId)
                    .SetProperty(b => b.AnimalId, b => animalId));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Adoption
                .Where(b => b.Id == id)
            .ExecuteDeleteAsync();

            return id;
        }
    }
}