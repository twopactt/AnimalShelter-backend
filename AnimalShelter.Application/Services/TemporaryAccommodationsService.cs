using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Repositories;

namespace AnimalShelter.Application.Services
{
    public class TemporaryAccommodationsService : ITemporaryAccommodationsService
    {
        private readonly ITemporaryAccommodationsRepository _temporaryAccommodationsRepository;
        public TemporaryAccommodationsService(ITemporaryAccommodationsRepository temporaryAccommodationRepository)
        {
            _temporaryAccommodationsRepository = temporaryAccommodationRepository;
        }

        public async Task<List<TemporaryAccommodation>> GetAllTemporaryAccommodations()
        {
            return await _temporaryAccommodationsRepository.Get();
        }

        public async Task<Guid> CreateTemporaryAccommodation(TemporaryAccommodation temporaryAccommodation)
        {
            return await _temporaryAccommodationsRepository.Create(temporaryAccommodation);
        }

        public async Task<Guid> UpdateTemporaryAccommodation(
            Guid id,
            DateOnly dateAnimalCapture,
            DateOnly dateAnimalReturn,
            Guid userId,
            Guid animalId)
        {
            return await _temporaryAccommodationsRepository.Update(
                id, dateAnimalCapture, dateAnimalReturn, userId, animalId);
        }

        public async Task<Guid> DeleteTemporaryAccommodation(Guid id)
        {
            return await _temporaryAccommodationsRepository.Delete(id);
        }
    }
}