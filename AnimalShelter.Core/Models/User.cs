namespace AnimalShelter.Core.Models
{
    public class User
    {
        public const int MAX_NAME_LENGTH = 250;
        private User(
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
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            Login = login;
            Password = password;
            RoleId = roleId;
        }

        public Guid Id { get; }

        public string Surname { get; }

        public string Name { get; }

        public string Patronymic { get; } = string.Empty;

        public DateOnly DateOfBirth { get; }

        public string Phone { get; }

        public string Email { get; }

        public string Login { get; }

        public string Password { get; }

        public Guid RoleId { get; }

        // Навигационные свойства
        public Role Role { get; private set; }

        public static (User User, string Error) Create(
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
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = "Name can not be empty or longer then 250 symbols";
            }

            // Проверка обязательных внешних ключей
            if (roleId == Guid.Empty)
                error += string.IsNullOrEmpty(error) ? "Role is required" : "\nRole is required";

            var user = new User(id, surname, name, patronymic, dateOfBirth, phone, email, login, password, roleId);

            return (user, error);
        }
    }
}