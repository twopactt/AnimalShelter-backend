using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
    }
}