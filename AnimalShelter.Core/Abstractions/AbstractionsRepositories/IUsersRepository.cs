using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Repositories
{
    public interface IUsersRepository
    {
        Task<Guid> Create(User user);
        Task<Guid> Delete(Guid id);
        Task<List<User>> Get();
        Task<User?> GetById(Guid id);
        Task<Guid> Update(Guid id, string surname, string name, string patronymic, DateOnly dateOfBirth, string phone, string email, string login, string password, Guid roleId);
    }
}