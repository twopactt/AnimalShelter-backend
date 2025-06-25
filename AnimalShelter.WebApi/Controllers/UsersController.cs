using AnimalShelter.Application.Services;
using AnimalShelter.Contracts.ContractsRequests;
using AnimalShelter.Contracts.ContractsResponses;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await _usersService.GetAllUsers();

            var response = users.Select(b => new UsersResponse(b.Id, b.Surname, b.Name, b.Patronymic, b.DateOfBirth, b.Phone, b.Email, b.Login, b.Password, b.RoleId));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsersResponse>> GetUserById(Guid id)
        {
            var user = await _usersService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            var response = new UsersResponse(
                user.Id,
                user.Surname,
                user.Name,
                user.Patronymic,
                user.DateOfBirth,
                user.Phone,
                user.Email,
                user.Login,
                user.Password,
                user.RoleId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UsersRequest request)
        {
            var (user, error) = Core.Models.User.Create(
                Guid.NewGuid(),
                request.Surname,
                request.Name,
                request.Patronymic,
                request.DateOfBirth,
                request.Phone,
                request.Email,
                request.Login,
                request.Password,
                request.RoleId);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var userId = await _usersService.CreateUser(user);

            return Ok(userId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateUsers(Guid id, [FromBody] UsersRequest request)
        {
            var userId = await _usersService.UpdateUser(
                id,
                request.Surname,
                request.Name,
                request.Patronymic,
                request.DateOfBirth,
                request.Phone,
                request.Email,
                request.Login,
                request.Password,
                request.RoleId);

            return Ok(userId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid id)
        {
            return Ok(await _usersService.DeleteUser(id));
        }
    }
}