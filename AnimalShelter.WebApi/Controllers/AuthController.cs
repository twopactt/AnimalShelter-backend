using AnimalShelter.Application.Services;
using AnimalShelter.Contracts.ContractsRequests;
using AnimalShelter.Contracts.ContractsResponses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimalShelter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUsersService _usersService;

        public AuthController(IAuthService authService, IUsersService usersService)
        {
            _authService = authService;
            _usersService = usersService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthsResponse>> Login([FromBody] LoginsRequest request)
        {
            try
            {
                var (token, user) = await _authService.Login(request.Login, request.Password);

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                new Claim("UserId", user.Id.ToString()),
                new Claim("JwtToken", token)
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7),
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Ok(new AuthsResponse(
                    token,
                    new UsersResponse(
                        user.Id,
                        user.Surname,
                        user.Name,
                        user.Patronymic,
                        user.DateOfBirth,
                        user.Phone,
                        user.Email,
                        user.Login,
                        user.Password,
                        user.RoleId
                    )
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthsResponse>> Register([FromBody] UsersRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest(new { message = "Request body is null" });
                }

                if (string.IsNullOrEmpty(request.Login) ||
                    string.IsNullOrEmpty(request.Password) ||
                    string.IsNullOrEmpty(request.Email) ||
                    request.RoleId == Guid.Empty)
                {
                    return BadRequest(new { message = "Required fields are missing" });
                }

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
                    request.RoleId
                );

                if (!string.IsNullOrEmpty(error))
                {
                    return BadRequest(new { message = error });
                }


                var (token, createdUser) = await _authService.Register(user);

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, createdUser.Login),
                new Claim(ClaimTypes.Email, createdUser.Email),
                new Claim(ClaimTypes.Role, createdUser.RoleId.ToString()),
                new Claim("UserId", createdUser.Id.ToString()),
                new Claim("JwtToken", token)
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7),
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Ok(new AuthsResponse(
                    token,
                    new UsersResponse(
                        createdUser.Id,
                        createdUser.Surname,
                        createdUser.Name,
                        createdUser.Patronymic,
                        createdUser.DateOfBirth,
                        createdUser.Phone,
                        createdUser.Email,
                        createdUser.Login,
                        createdUser.Password,
                        createdUser.RoleId
                    )
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("current-user")]
        [Authorize]
        public async Task<ActionResult<UsersResponse>> GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return BadRequest("Нет пользователя с таким id");

            var user = await _usersService.GetUserById(Guid.Parse(userId));

            if (user is null)
                return BadRequest("Пользователь с таким id не найден либо возникла ошибка при его поиске");

            return Ok(new UsersResponse(
                user.Id,
                user.Surname,
                user.Name,
                user.Patronymic,
                user.DateOfBirth,
                user.Phone,
                user.Email,
                user.Login,
                user.Password,
                user.RoleId
            ));
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { message = "Successfully logged out" });
        }
    }
}