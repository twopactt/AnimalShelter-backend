namespace AnimalShelter.DataAccess.Entities
{
    public class RoleEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserEntity> User { get; set; }
    }
}