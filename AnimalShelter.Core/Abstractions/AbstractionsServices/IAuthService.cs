using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface IAuthService
    {
        Task<(string Token, User User)> Login(string login, string password);
        Task<(string Token, User User)> Register(User user);
    }
}