using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface IAdoptionApplicationsService
    {
        Task<Guid> CreateAdoptionApplication(AdoptionApplication adoptionApplication);
        Task<Guid> DeleteAdoptionApplication(Guid id);
        Task<List<AdoptionApplication>> GetAllAdoptionApplications();
        Task<Guid> UpdateAdoptionApplication(Guid id, DateOnly applicationDate, string comment, Guid userId, Guid animalId, Guid statusAdoptionId);
    }
}