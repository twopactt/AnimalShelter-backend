namespace AnimalShelter.Core.Models
{
    public class TemporaryAccommodation
    {
        private TemporaryAccommodation(
            Guid id,
            DateOnly dateAnimalCapture,
            DateOnly dateAnimalReturn,
            Guid userId,
            Guid animalId)
        {
            Id = id;
            DateAnimalCapture = dateAnimalCapture;
            DateAnimalReturn = dateAnimalReturn;
            UserId = userId;
            AnimalId = animalId;
        }

        public Guid Id { get; }

        public DateOnly DateAnimalCapture { get; }

        public DateOnly DateAnimalReturn { get; }

        //Внешние ключи
        public Guid UserId { get; }

        public Guid AnimalId { get; }

        // Навигационные свойства
        public User User { get; private set; }

        public Animal Animal { get; private set; }

        public static (TemporaryAccommodation TemporaryAccommodation, string Error) Create(
            Guid id,
            DateOnly dateAnimalCapture,
            DateOnly dateAnimalReturn,
            Guid userId,
            Guid animalId)
        {
            var error = string.Empty;

            // Проверка обязательных внешних ключей
            if (userId == Guid.Empty)
                error += string.IsNullOrEmpty(error) ? "User is required" : "\nUser is required";

            if (animalId == Guid.Empty)
                error += string.IsNullOrEmpty(error) ? "Animal is required" : "\nAnimal is required";

            var temporaryAccommodation = new TemporaryAccommodation(id, dateAnimalCapture, dateAnimalReturn, userId, animalId);

            return (temporaryAccommodation, error);
        }
    }
}