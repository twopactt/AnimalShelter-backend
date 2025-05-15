using System.Xml.Linq;

namespace AnimalShelter.Core.Models
{
    public class AdoptionApplication
    {
        public const int MAX_COMMENT_LENGTH = 250;
        private AdoptionApplication(
            Guid id,
            DateOnly applicationDate,
            string comment,
            Guid userId,
            Guid animalId,
            Guid statusAdoptionId)
        {
            Id = id;
            ApplicationDate = applicationDate;
            Comment = comment;
            UserId = userId;
            AnimalId = animalId;
            StatusAdoptionId = statusAdoptionId;
        }

        public Guid Id { get; }

        public DateOnly ApplicationDate { get; }

        public string Comment { get; } = string.Empty;

        //Внешние ключи
        public Guid UserId { get; }

        public Guid AnimalId { get; }

        public Guid StatusAdoptionId { get; }

        // Навигационные свойства
        public User User { get; private set; }

        public Animal Animal { get; private set; }

        public StatusAdoption StatusAdoption { get; private set; }

        public static (AdoptionApplication AdoptionApplication, string Error) Create(
            Guid id,
            DateOnly applicationDate,
            string comment,
            Guid userId,
            Guid animalId,
            Guid statusAdoptionId)
        {
            var error = string.Empty;

            if (comment.Length > MAX_COMMENT_LENGTH)
            {
                error = "Comment can not be longer then 250 symbols";
            }

            // Проверка обязательных внешних ключей
            if (userId == Guid.Empty)
                error += string.IsNullOrEmpty(error) ? "User is required" : "\nUser is required";

            if (animalId == Guid.Empty)
                error += string.IsNullOrEmpty(error) ? "Animal is required" : "\nAnimal is required";

            if (statusAdoptionId == Guid.Empty)
                error += string.IsNullOrEmpty(error) ? "StatusAdoption info is required" : "\nStatusAdoption info is required";

            var adoptionApplication = new AdoptionApplication(id, applicationDate, comment, userId, animalId, statusAdoptionId);

            return (adoptionApplication, error);
        }
    }
}