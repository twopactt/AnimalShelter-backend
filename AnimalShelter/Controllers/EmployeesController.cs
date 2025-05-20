using AnimalShelter.Application.Services;
using AnimalShelter.Contracts.ContractsRequests;
using AnimalShelter.Contracts.ContractsResponses;
using AnimalShelter.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeesResponse>>> GetEmployees()
        {
            var employees = await _employeesService.GetAllEmployees();

            var response = employees.Select(b => new EmployeesResponse(b.Id, b.IsAdmin, b.UserId));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateEmployee([FromBody] EmployeesRequest request)
        {
            var (employee, error) = Employee.Create(
                Guid.NewGuid(),
                request.UserId,
                request.IsAdmin);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var employeeId = await _employeesService.CreateEmployee(employee);

            return Ok(employeeId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateEmployees(Guid id, [FromBody] EmployeesRequest request)
        {
            var employeeId = await _employeesService.UpdateEmployee(
                id,
                request.IsAdmin,
                request.UserId);

            return Ok(employeeId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteEmployee(Guid id)
        {
            return Ok(await _employeesService.DeleteEmployee(id));
        }
    }
}