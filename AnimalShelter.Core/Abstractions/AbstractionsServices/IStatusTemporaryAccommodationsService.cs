using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface IStatusTemporaryAccommodationsService
    {
        Task<List<StatusTemporaryAccommodation>> GetAllStatusTemporaryAccommodations();
    }
}