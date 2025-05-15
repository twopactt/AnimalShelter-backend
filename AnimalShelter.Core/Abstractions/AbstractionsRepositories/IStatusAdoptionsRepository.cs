using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Repositories
{
    public interface IStatusAdoptionsRepository
    {
        Task<List<StatusAdoption>> Get();
    }
}