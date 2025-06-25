using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace AnimalShelter.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AnimalShelterDbContext _context;

        public UsersRepository(AnimalShelterDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Get()
        {
            var userEntities = await _context.User
                .AsNoTracking()
                .ToListAsync();

            var users = userEntities
                .Select(b => User.Create(b.Id, b.Surname, b.Name, b.Patronymic, b.DateOfBirth, b.Phone, b.Email, b.Login, b.Password, b.RoleId).User)
                .ToList();

            return users;
        }

        public async Task<User?> GetById(Guid id)
        {
            var userEntity = await _context.User
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (userEntity == null)
                return null;

            return User.Create(
                userEntity.Id,
                userEntity.Surname,
                userEntity.Name,
                userEntity.Patronymic,
                userEntity.DateOfBirth,
                userEntity.Phone,
                userEntity.Email,
                userEntity.Login,
                userEntity.Password,
                userEntity.RoleId).User;
        }

        public async Task<Guid> Create(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Surname = user.Surname,
                Name = user.Name,
                Patronymic = user.Patronymic,
                DateOfBirth = user.DateOfBirth,
                Phone = user.Phone,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                RoleId = user.RoleId
            };

            await _context.User.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<Guid> Update(
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
            await _context.User
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Surname, b => surname)
                    .SetProperty(b => b.Name, b => name)
                    .SetProperty(b => b.Patronymic, b => patronymic)
                    .SetProperty(b => b.DateOfBirth, b => dateOfBirth)
                    .SetProperty(b => b.Phone, b => phone)
                    .SetProperty(b => b.Email, b => email)
                    .SetProperty(b => b.Login, b => login)
                    .SetProperty(b => b.Password, b => password)
                    .SetProperty(b => b.RoleId, b => roleId));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.User
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}