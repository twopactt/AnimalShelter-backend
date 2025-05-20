namespace AnimalShelter.DataAccess.Entities
{
    public class StatusAdoptionEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<AdoptionApplicationEntity> AdoptionApplication { get; set; }
    }
}