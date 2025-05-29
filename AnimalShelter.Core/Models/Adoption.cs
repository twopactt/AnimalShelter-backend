namespace AnimalShelter.Core.Models
{
    public class Adoption
    {
        public const int MAX_NAME_LENGTH = 250;
        private Adoption(
            Guid id,
            DateOnly applicationDate,
            Guid userId,
            Guid animalId)
        {
            Id = id;
            ApplicationDate = applicationDate;
            UserId = userId;
            AnimalId = animalId;
        }

        public Guid Id { get; }

        public DateOnly ApplicationDate { get; }

        //Внешние ключи
        public Guid UserId { get; }

        public Guid AnimalId { get; }

        // Навигационные свойства
        public User User { get; private set; }

        public Animal Animal { get; private set; }

        public static (Adoption Adoption, string Error) Create(
            Guid id,
            DateOnly applicationDate,
            Guid userId,
            Guid animalId)
        {
            var error = string.Empty;

            // Проверка обязательных внешних ключей
            if (userId == Guid.Empty)
                error += string.IsNullOrEmpty(error) ? "User is required" : "\nUser is required";

            if (animalId == Guid.Empty)
                error += string.IsNullOrEmpty(error) ? "Animal is required" : "\nAnimal is required";

            var adoption = new Adoption(id, applicationDate, userId, animalId);

            return (adoption, error);
        }
    }
}