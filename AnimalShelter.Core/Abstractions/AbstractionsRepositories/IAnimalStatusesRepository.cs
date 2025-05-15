using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Repositories
{
    public interface IAnimalStatusesRepository
    {
        Task<List<AnimalStatus>> Get();
    }
}