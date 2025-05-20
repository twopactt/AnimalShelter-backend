using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Repositories
{
    public interface ITypeAnimalsRepository
    {
        Task<List<TypeAnimal>> Get();
    }
}