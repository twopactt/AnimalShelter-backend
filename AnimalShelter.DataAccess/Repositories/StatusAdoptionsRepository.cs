using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.DataAccess.Repositories
{
    public class StatusAdoptionsRepository : IStatusAdoptionsRepository
    {
        private readonly AnimalShelterDbContext _context;

        public StatusAdoptionsRepository(AnimalShelterDbContext context)
        {
            _context = context;
        }

        public async Task<List<StatusAdoption>> Get()
        {
            var statusAdoptionEntities = await _context.StatusAdoption
                .AsNoTracking()
                .ToListAsync();

            var statusAdoptions = statusAdoptionEntities
                .Select(b => StatusAdoption.Create(b.Id, b.Name).StatusAdoption)
                .ToList();

            return statusAdoptions;
        }
    }
}