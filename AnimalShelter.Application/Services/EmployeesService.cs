using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Repositories;

namespace AnimalShelter.Application.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        public EmployeesService(IEmployeesRepository employeeRepository)
        {
            _employeesRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _employeesRepository.Get();
        }

        public async Task<Guid> CreateEmployee(Employee employee)
        {
            return await _employeesRepository.Create(employee);
        }

        public async Task<Guid> UpdateEmployee(
            Guid id,
            bool isAdmin,
            Guid userId)
        {
            return await _employeesRepository.Update(
                id, isAdmin, userId);
        }

        public async Task<Guid> DeleteEmployee(Guid id)
        {
            return await _employeesRepository.Delete(id);
        }
    }
}