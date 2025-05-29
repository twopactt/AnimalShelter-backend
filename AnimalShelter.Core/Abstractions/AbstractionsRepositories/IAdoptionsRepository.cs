using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Repositories
{
    public interface IAdoptionsRepository
    {
        Task<Guid> Create(Adoption adoption);
        Task<Guid> Delete(Guid id);
        Task<List<Adoption>> Get();
        Task<Guid> Update(Guid id, DateOnly applicationDate, Guid userId, Guid animalId);
    }
}