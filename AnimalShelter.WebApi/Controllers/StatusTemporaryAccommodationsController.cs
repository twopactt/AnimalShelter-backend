using AnimalShelter.Application.Services;
using AnimalShelter.Contracts.ContractsRequests;
using AnimalShelter.Contracts.ContractsResponses;
using AnimalShelter.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusTemporaryAccommodationsController : ControllerBase
    {
        private readonly IStatusTemporaryAccommodationsService _statusTemporaryAccommodationsService;

        public StatusTemporaryAccommodationsController(IStatusTemporaryAccommodationsService statusTemporaryAccommodationsService)
        {
            _statusTemporaryAccommodationsService = statusTemporaryAccommodationsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusTemporaryAccommodationsResponse>>> GetStatusTemporaryAccommodations()
        {
            var statusTemporaryAccommodations = await _statusTemporaryAccommodationsService.GetAllStatusTemporaryAccommodations();

            var response = statusTemporaryAccommodations.Select(b => new StatusTemporaryAccommodationsResponse(b.Id, b.Name));

            return Ok(response);
        }
    }
}