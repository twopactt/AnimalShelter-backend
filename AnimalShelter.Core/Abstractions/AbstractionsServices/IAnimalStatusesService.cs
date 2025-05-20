using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface IAnimalStatusesService
    {
        Task<List<AnimalStatus>> GetAllAnimalStatuses();
    }
}