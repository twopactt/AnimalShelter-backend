using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Repositories;

namespace AnimalShelter.Application.Services
{
    public class AdoptionsService : IAdoptionsService
    {
        private readonly IAdoptionsRepository _adoptionsRepository;
        public AdoptionsService(IAdoptionsRepository adoptionRepository)
        {
            _adoptionsRepository = adoptionRepository;
        }

        public async Task<List<Adoption>> GetAllAdoptions()
        {
            return await _adoptionsRepository.Get();
        }

        public async Task<Guid> CreateAdoption(Adoption adoption)
        {
            return await _adoptionsRepository.Create(adoption);
        }

        public async Task<Guid> UpdateAdoption(
            Guid id,
            DateOnly applicationDate,
            Guid userId,
            Guid animalId,
            Guid employeeId)
        {
            return await _adoptionsRepository.Update(
                id, applicationDate, userId, animalId, employeeId);
        }

        public async Task<Guid> DeleteAdoption(Guid id)
        {
            return await _adoptionsRepository.Delete(id);
        }
    }
}