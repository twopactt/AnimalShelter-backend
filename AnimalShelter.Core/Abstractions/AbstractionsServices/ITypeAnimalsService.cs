using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface ITypeAnimalsService
    {
        Task<List<TypeAnimal>> GetAllTypeAnimals();
    }
}