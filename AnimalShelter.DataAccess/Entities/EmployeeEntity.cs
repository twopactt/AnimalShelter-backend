namespace AnimalShelter.DataAccess.Entities
{
    public class EmployeeEntity
    {
        public Guid Id { get; set; }

        public bool IsAdmin { get; set; }

        // Внешние ключи
        public Guid UserId { get; set; }

        // Навигационные свойства
        public virtual UserEntity User { get; set; }

        public ICollection<TemporaryAccommodationEntity> TemporaryAccommodation { get; set; }

        public ICollection<AdoptionEntity> Adoption { get; set; }
    }
}