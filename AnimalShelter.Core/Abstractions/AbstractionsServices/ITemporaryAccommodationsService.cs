using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface ITemporaryAccommodationsService
    {
        Task<Guid> CreateTemporaryAccommodation(TemporaryAccommodation temporaryAccommodation);
        Task<Guid> DeleteTemporaryAccommodation(Guid id);
        Task<List<TemporaryAccommodation>> GetAllTemporaryAccommodations();
        Task<Guid> UpdateTemporaryAccommodation(Guid id, DateOnly dateAnimalCapture, DateOnly dateAnimalReturn, Guid userId, Guid animalId);
    }
}