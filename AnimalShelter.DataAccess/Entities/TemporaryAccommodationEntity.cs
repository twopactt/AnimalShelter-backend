namespace AnimalShelter.DataAccess.Entities
{
    public class TemporaryAccommodationEntity
    {
        public Guid Id { get; set; }

        public DateOnly DateAnimalCapture { get; set; }

        public DateOnly DateAnimalReturn { get; set; }

        //Внешние ключи
        public Guid UserId { get; set; }

        public Guid AnimalId { get; set; }

        // Навигационные свойства
        public virtual UserEntity User { get; set; }
        public virtual AnimalEntity Animal { get; set; }
    }
}