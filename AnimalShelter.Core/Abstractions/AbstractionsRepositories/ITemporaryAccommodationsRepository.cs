using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Repositories
{
    public interface ITemporaryAccommodationsRepository
    {
        Task<Guid> Create(TemporaryAccommodation temporaryAccommodation);
        Task<Guid> Delete(Guid id);
        Task<List<TemporaryAccommodation>> Get();
        Task<Guid> Update(Guid id, DateOnly dateAnimalCapture, DateOnly dateAnimalReturn, Guid userId, Guid animalId);
    }
}