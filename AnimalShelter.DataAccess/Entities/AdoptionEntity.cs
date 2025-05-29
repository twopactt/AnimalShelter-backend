using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Entities
{
    public class AdoptionEntity
    {
        public Guid Id { get; set; }

        public DateOnly ApplicationDate { get; set; }

        //Внешние ключи
        public Guid UserId { get; set; }

        public Guid AnimalId { get; set; }

        // Навигационные свойства
        public virtual UserEntity User { get; set; }
        public virtual AnimalEntity Animal { get; set; }
    }
}