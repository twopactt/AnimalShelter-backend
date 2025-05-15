namespace AnimalShelter.DataAccess.Entities
{
    public class AnimalEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Photo { get; set; }

        //Внешние ключи
        public Guid TypeAnimalId { get; set; }

        public Guid AnimalStatusId { get; set; }

        // Навигационные свойства
        public virtual TypeAnimalEntity TypeAnimal { get; set; }
        public virtual AnimalStatusEntity AnimalStatus { get; set; }

        public ICollection<AdoptionEntity> Adoption { get; set; }

        public ICollection<AdoptionApplicationEntity> AdoptionApplication { get; set; }

        public ICollection<TemporaryAccommodationEntity> TemporaryAccommodation { get; set; }
    }
}