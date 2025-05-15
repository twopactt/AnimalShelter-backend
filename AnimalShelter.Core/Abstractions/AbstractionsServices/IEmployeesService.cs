using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface IEmployeesService
    {
        Task<Guid> CreateEmployee(Employee employee);
        Task<Guid> DeleteEmployee(Guid id);
        Task<List<Employee>> GetAllEmployees();
        Task<Guid> UpdateEmployee(Guid id, bool isAdmin, Guid userId);
    }
}