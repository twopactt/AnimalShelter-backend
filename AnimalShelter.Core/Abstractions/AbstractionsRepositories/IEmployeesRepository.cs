using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Repositories
{
    public interface IEmployeesRepository
    {
        Task<Guid> Create(Employee employee);
        Task<Guid> Delete(Guid id);
        Task<List<Employee>> Get();
        Task<Guid> Update(Guid id, bool isAdmin, Guid userId);
    }
}