using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Repositories;

namespace AnimalShelter.Application.Services
{
    public class TypeAnimalsService : ITypeAnimalsService
    {
        private readonly ITypeAnimalsRepository _typeAnimalsRepository;
        public TypeAnimalsService(ITypeAnimalsRepository typeAnimalRepository)
        {
            _typeAnimalsRepository = typeAnimalRepository;
        }

        public async Task<List<TypeAnimal>> GetAllTypeAnimals()
        {
            return await _typeAnimalsRepository.Get();
        }
    }
}