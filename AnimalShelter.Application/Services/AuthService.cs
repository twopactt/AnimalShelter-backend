using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersService _usersService;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasherService _passwordHasher;

        public AuthService(
            IUsersService usersService,
            IJwtService jwtService,
            IPasswordHasherService passwordHasher)
        {
            _usersService = usersService;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        public async Task<(string Token, User User)> Login(string login, string password)
        {
            var users = await _usersService.GetAllUsers();
            var user = users.FirstOrDefault(u => u.Login == login);

            if (user == null || !_passwordHasher.VerifyPassword(password, user.Password))
            {
                throw new Exception("Неверный логин или пароль");
            }

            var token = _jwtService.GenerateToken(user);
            return (token, user);
        }

        public async Task<(string Token, User User)> Register(User user)
        {
            var users = await _usersService.GetAllUsers();

            if (users.Any(u => u.Login == user.Login))
            {
                throw new Exception("Пользователь с таким логином уже существует");
            }

            if (users.Any(u => u.Email == user.Email))
            {
                throw new Exception("Пользователь с таким email уже существует");
            }

            var hashedPassword = _passwordHasher.HashPassword(user.Password);

            var (userWithHashedPassword, error) = User.Create(
                user.Id,
                user.Surname,
                user.Name,
                user.Patronymic,
                user.DateOfBirth,
                user.Phone,
                user.Email,
                user.Login,
                hashedPassword,
                user.RoleId
            );

            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception(error);
            }

            var userId = await _usersService.CreateUser(userWithHashedPassword);
            var createdUser = (await _usersService.GetAllUsers()).First(u => u.Id == userId);

            var token = _jwtService.GenerateToken(createdUser);
            return (token, createdUser);
        }
    }
}