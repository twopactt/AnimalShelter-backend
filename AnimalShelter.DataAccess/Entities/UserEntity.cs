namespace AnimalShelter.DataAccess.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        // Внешние ключи
        public Guid RoleId { get; set; }

        // Навигационные свойства
        public virtual RoleEntity Role { get; set; }

        public ICollection<AdoptionEntity> Adoption { get; set; }

        public ICollection<AdoptionApplicationEntity> AdoptionApplication { get; set; }

        public ICollection<TemporaryAccommodationEntity> TemporaryAccommodation { get; set; }
    }
}