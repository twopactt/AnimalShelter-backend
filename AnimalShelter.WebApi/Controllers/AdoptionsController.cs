using AnimalShelter.Application.Services;
using AnimalShelter.Contracts.ContractsRequests;
using AnimalShelter.Contracts.ContractsResponses;
using AnimalShelter.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdoptionsController : ControllerBase
    {
        private readonly IAdoptionsService _adoptionsService;

        public AdoptionsController(IAdoptionsService adoptionsService)
        {
            _adoptionsService = adoptionsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdoptionsResponse>>> GetAdoptions()
        {
            var adoptions = await _adoptionsService.GetAllAdoptions();

            var response = adoptions.Select(b => new AdoptionsResponse(b.Id, b.ApplicationDate, b.UserId, b.AnimalId));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAdoption([FromBody] AdoptionsRequest request)
        {
            var (adoption, error) = Adoption.Create(
                Guid.NewGuid(),
                request.ApplicationDate,
                request.UserId,
                request.AnimalId);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var adoptionId = await _adoptionsService.CreateAdoption(adoption);

            return Ok(adoptionId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateAdoptions(Guid id, [FromBody] AdoptionsRequest request)
        {
            var adoptionId = await _adoptionsService.UpdateAdoption(
                id,
                request.ApplicationDate,
                request.UserId,
                request.AnimalId);

            return Ok(adoptionId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteAdoption(Guid id)
        {
            return Ok(await _adoptionsService.DeleteAdoption(id));
        }
    }
}