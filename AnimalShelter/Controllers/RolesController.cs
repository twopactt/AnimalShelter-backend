using AnimalShelter.Application.Services;
using AnimalShelter.Contracts.ContractsResponses;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RolesResponse>>> GetRoles()
        {
            var roles = await _rolesService.GetAllRoles();

            var response = roles.Select(b => new RolesResponse(b.Id, b.Name));

            return Ok(response);
        }
    }
}