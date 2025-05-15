using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Repositories;

namespace AnimalShelter.Application.Services
{
    public class StatusAdoptionsService : IStatusAdoptionsService
    {
        private readonly IStatusAdoptionsRepository _statusAdoptionsRepository;
        public StatusAdoptionsService(IStatusAdoptionsRepository statusAdoptionRepository)
        {
            _statusAdoptionsRepository = statusAdoptionRepository;
        }

        public async Task<List<StatusAdoption>> GetAllStatusAdoptions()
        {
            return await _statusAdoptionsRepository.Get();
        }
    }
}