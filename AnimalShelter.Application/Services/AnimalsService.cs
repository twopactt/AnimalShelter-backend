using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Repositories;

namespace AnimalShelter.Application.Services
{
    public class AnimalsService : IAnimalsService
    {
        private readonly IAnimalsRepository _animalsRepository;
        public AnimalsService(IAnimalsRepository animalRepository)
        {
            _animalsRepository = animalRepository;
        }

        public async Task<List<Animal>> GetAllAnimals()
        {
            return await _animalsRepository.Get();
        }

        public async Task<Guid> CreateAnimal(Animal animal)
        {
            return await _animalsRepository.Create(animal);
        }

        public async Task<Guid> UpdateAnimal(
            Guid id,
            string name,
            string gender,
            int age,
            string description,
            string photo,
            Guid typeAnimalId,
            Guid animalStatusId)
        {
            return await _animalsRepository.Update(
                id, name, gender, age, description, photo,
                typeAnimalId, animalStatusId);
        }

        public async Task<Guid> DeleteAnimal(Guid id)
        {
            return await _animalsRepository.Delete(id);
        }
    }
}