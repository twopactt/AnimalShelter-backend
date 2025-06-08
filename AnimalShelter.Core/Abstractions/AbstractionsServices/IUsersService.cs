using AnimalShelter.Core.Models;

namespace AnimalShelter.Application.Services
{
    public interface IUsersService
    {
        Task<Guid> CreateUser(User user);
        Task<Guid> DeleteUser(Guid id);
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(Guid id);
        Task<Guid> UpdateUser(Guid id, string surname, string name, string patronymic, DateOnly dateOfBirth, string phone, string email, string login, string password, Guid roleId);
    }
}