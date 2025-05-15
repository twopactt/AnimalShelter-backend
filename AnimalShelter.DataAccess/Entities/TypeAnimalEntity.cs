namespace AnimalShelter.DataAccess.Entities
{
    public class TypeAnimalEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<AnimalEntity> Animal { get; set; }
    }
}