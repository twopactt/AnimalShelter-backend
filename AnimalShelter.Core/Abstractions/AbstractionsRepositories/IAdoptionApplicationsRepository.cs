using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Repositories
{
    public interface IAdoptionApplicationsRepository
    {
        Task<Guid> Create(AdoptionApplication adoptionApplication);
        Task<Guid> Delete(Guid id);
        Task<List<AdoptionApplication>> Get();
        Task<Guid> Update(Guid id, DateOnly applicationDate, string comment, Guid userId, Guid animalId, Guid statusAdoptionId);
    }
}