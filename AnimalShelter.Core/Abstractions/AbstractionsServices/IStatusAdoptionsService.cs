using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface IStatusAdoptionsService
    {
        Task<List<StatusAdoption>> GetAllStatusAdoptions();
    }
}