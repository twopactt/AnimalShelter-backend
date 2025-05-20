using AnimalShelter.Application.Services;
using AnimalShelter.Contracts.ContractsResponses;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusAdoptionsController : ControllerBase
    {
        private readonly IStatusAdoptionsService _statusAdoptionsService;

        public StatusAdoptionsController(IStatusAdoptionsService statusAdoptionsService)
        {
            _statusAdoptionsService = statusAdoptionsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusAdoptionsResponse>>> GetStatusAdoptions()
        {
            var statusAdoptions = await _statusAdoptionsService.GetAllStatusAdoptions();

            var response = statusAdoptions.Select(b => new StatusAdoptionsResponse(b.Id, b.Name));

            return Ok(response);
        }
    }
}