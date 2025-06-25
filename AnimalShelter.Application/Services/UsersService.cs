using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Repositories;

namespace AnimalShelter.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository userRepository)
        {
            _usersRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _usersRepository.Get();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _usersRepository.GetById(id);
        }

        public async Task<Guid> CreateUser(User user)
        {
            return await _usersRepository.Create(user);
        }

        public async Task<Guid> UpdateUser(
            Guid id,
            string surname,
            string name,
            string patronymic,
            DateOnly dateOfBirth,
            string phone,
            string email,
            string login,
            string password,
            Guid roleId)
        {
            return await _usersRepository.Update(
                id, surname, name, patronymic, dateOfBirth, phone, email, login, password, roleId);
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            return await _usersRepository.Delete(id);
        }
    }
}