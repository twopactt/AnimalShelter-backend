namespace AnimalShelter.DataAccess.Entities
{
    public class StatusTemporaryAccommodationEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<TemporaryAccommodationEntity> TemporaryAccommodation { get; set; }
    }
}