using AnimalShelter.Application.Services;
using AnimalShelter.Contracts.ContractsRequests;
using AnimalShelter.Contracts.ContractsResponses;
using AnimalShelter.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemporaryAccommodationsController : ControllerBase
    {
        private readonly ITemporaryAccommodationsService _temporaryAccommodationsService;

        public TemporaryAccommodationsController(ITemporaryAccommodationsService temporaryAccommodationsService)
        {
            _temporaryAccommodationsService = temporaryAccommodationsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TemporaryAccommodationsResponse>>> GetTemporaryAccommodations()
        {
            var temporaryAccommodations = await _temporaryAccommodationsService.GetAllTemporaryAccommodations();

            var response = temporaryAccommodations.Select(b => new TemporaryAccommodationsResponse(b.Id, b.DateAnimalCapture, b.DateAnimalReturn, b.UserId, b.AnimalId));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateTemporaryAccommodation([FromBody] TemporaryAccommodationsRequest request)
        {
            var (temporaryAccommodation, error) = TemporaryAccommodation.Create(
                Guid.NewGuid(),
                request.DateAnimalCapture,
                request.DateAnimalReturn,
                request.UserId,
                request.AnimalId);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var temporaryAccommodationId = await _temporaryAccommodationsService.CreateTemporaryAccommodation(temporaryAccommodation);

            return Ok(temporaryAccommodationId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateTemporaryAccommodations(Guid id, [FromBody] TemporaryAccommodationsRequest request)
        {
            var temporaryAccommodationId = await _temporaryAccommodationsService.UpdateTemporaryAccommodation(
                id,
                request.DateAnimalCapture,
                request.DateAnimalReturn,
                request.UserId,
                request.AnimalId);

            return Ok(temporaryAccommodationId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteTemporaryAccommodation(Guid id)
        {
            return Ok(await _temporaryAccommodationsService.DeleteTemporaryAccommodation(id));
        }
    }
}