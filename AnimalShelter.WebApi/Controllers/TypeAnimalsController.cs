using AnimalShelter.Application.Services;
using AnimalShelter.Contracts.ContractsResponses;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeAnimalsController : ControllerBase
    {
        private readonly ITypeAnimalsService _typeAnimalsService;

        public TypeAnimalsController(ITypeAnimalsService typeAnimalsService)
        {
            _typeAnimalsService = typeAnimalsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypeAnimalsResponse>>> GetTypeAnimals()
        {
            var typeAnimals = await _typeAnimalsService.GetAllTypeAnimals();

            var response = typeAnimals.Select(b => new TypeAnimalsResponse(b.Id, b.Name));

            return Ok(response);
        }
    }
}