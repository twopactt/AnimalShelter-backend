using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Repositories
{
    public interface IStatusTemporaryAccommodationsRepository
    {
        Task<List<StatusTemporaryAccommodation>> Get();
    }
}