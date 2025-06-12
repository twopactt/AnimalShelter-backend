using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Repositories;

namespace AnimalShelter.Application.Services
{
    public class StatusTemporaryAccommodationsService : IStatusTemporaryAccommodationsService
    {
        private readonly IStatusTemporaryAccommodationsRepository _statusTemporaryAccommodationsRepository;
        public StatusTemporaryAccommodationsService(IStatusTemporaryAccommodationsRepository statusTemporaryAccommodationRepository)
        {
            _statusTemporaryAccommodationsRepository = statusTemporaryAccommodationRepository;
        }

        public async Task<List<StatusTemporaryAccommodation>> GetAllStatusTemporaryAccommodations()
        {
            return await _statusTemporaryAccommodationsRepository.Get();
        }
    }
}