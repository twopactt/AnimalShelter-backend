namespace AnimalShelter.DataAccess.Entities
{
    public class AnimalStatusEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<AnimalEntity> Animal { get; set; }
    }
}