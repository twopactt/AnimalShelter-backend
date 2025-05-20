using AnimalShelter.Application.Services;
using AnimalShelter.Contracts.ContractsResponses;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalStatusesController : ControllerBase
    {
        private readonly IAnimalStatusesService _animalStatusesService;

        public AnimalStatusesController(IAnimalStatusesService animalStatusesService)
        {
            _animalStatusesService = animalStatusesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalStatusesResponse>>> GetAnimalStatuses()
        {
            var animalStatuses = await _animalStatusesService.GetAllAnimalStatuses();

            var response = animalStatuses.Select(b => new AnimalStatusesResponse(b.Id, b.Name));

            return Ok(response);
        }
    }
}