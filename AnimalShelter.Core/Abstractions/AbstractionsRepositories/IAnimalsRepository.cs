using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Repositories
{
    public interface IAnimalsRepository
    {
        Task<Guid> Create(Animal animal);
        Task<Guid> Delete(Guid id);
        Task<List<Animal>> Get();
        Task<Guid> Update(Guid id, string name, string gender, int age, string description, string photo, Guid typeAnimalId, Guid animalStatusId);
    }
}