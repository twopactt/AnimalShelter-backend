namespace AnimalShelter.Core.Models
{
    public class Employee
    {
        private Employee(
            Guid id,
            bool isAdmin,
            Guid userId)
        {
            Id = id;
            IsAdmin = isAdmin;
            UserId = userId;
        }

        public Guid Id { get; }

        public bool IsAdmin { get; }

        //Внешние ключи
        public Guid UserId { get; }

        // Навигационные свойства
        public User User { get; private set; }

        public static (Employee Employee, string Error) Create(
            Guid id,
            Guid userId, 
            bool isAdmin = false)
        {
            var error = string.Empty;

            // Проверка обязательных внешних ключей
            if (userId == Guid.Empty)
                error += string.IsNullOrEmpty(error) ? "User is required" : "\nUser is required";

            var employee = new Employee(id, isAdmin, userId);

            return (employee, error);
        }
    }
}