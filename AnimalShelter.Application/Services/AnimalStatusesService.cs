using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Repositories;

namespace AnimalShelter.Application.Services
{
    public class AnimalStatusesService : IAnimalStatusesService
    {
        private readonly IAnimalStatusesRepository _animalStatusesRepository;
        public AnimalStatusesService(IAnimalStatusesRepository animalStatusRepository)
        {
            _animalStatusesRepository = animalStatusRepository;
        }

        public async Task<List<AnimalStatus>> GetAllAnimalStatuses()
        {
            return await _animalStatusesRepository.Get();
        }
    }
}