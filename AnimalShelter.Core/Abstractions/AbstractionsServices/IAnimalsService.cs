using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface IAnimalsService
    {
        Task<Guid> CreateAnimal(Animal animal);
        Task<Guid> DeleteAnimal(Guid id);
        Task<List<Animal>> GetAllAnimals();
        Task<Guid> UpdateAnimal(Guid id, string name, string gender, int age, string description, string photo, Guid typeAnimalId, Guid animalStatusId);
    }
}