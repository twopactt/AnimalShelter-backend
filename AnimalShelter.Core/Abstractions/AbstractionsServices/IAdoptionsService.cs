using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface IAdoptionsService
    {
        Task<Guid> CreateAdoption(Adoption adoption);
        Task<Guid> DeleteAdoption(Guid id);
        Task<List<Adoption>> GetAllAdoptions();
        Task<Guid> UpdateAdoption(Guid id, DateOnly applicationDate, Guid userId, Guid animalId);
    }
}