using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.DataAccess.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly AnimalShelterDbContext _context;

        public EmployeesRepository(AnimalShelterDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> Get()
        {
            var employeeEntities = await _context.Employee
                .AsNoTracking()
                .ToListAsync();

            var employees = employeeEntities
                .Select(b => Employee.Create(b.Id, b.UserId, b.IsAdmin).Employee)
                .ToList();

            return employees;
        }

        public async Task<Guid> Create(Employee employee)
        {
            var employeeEntity = new EmployeeEntity
            {
                Id = employee.Id,
                UserId = employee.UserId,
                IsAdmin = employee.IsAdmin
            };

            await _context.Employee.AddAsync(employeeEntity);
            await _context.SaveChangesAsync();

            return employeeEntity.Id;
        }

        public async Task<Guid> Update(
            Guid id,
            bool isAdmin,
            Guid userId)
        {
            await _context.Employee
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.IsAdmin, b => isAdmin)
                    .SetProperty(b => b.UserId, b => userId));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Employee
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}