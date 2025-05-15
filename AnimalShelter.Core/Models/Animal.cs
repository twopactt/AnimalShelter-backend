namespace AnimalShelter.Core.Models
{
    public class Animal
    {
        public const int MAX_NAME_LENGTH = 250;
        private Animal(
            Guid id, 
            string name, 
            string gender, 
            int age, 
            string description, 
            string photo,
            Guid typeAnimalId, 
            Guid animalStatusId)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;
            Description = description;
            Photo = photo;
            TypeAnimalId = typeAnimalId;
            AnimalStatusId = animalStatusId;
        }

        public Guid Id { get; }

        public string Name { get; }
        
        public string Gender { get; }

        public int Age { get; }

        public string Description { get; } = string.Empty;

        public string Photo { get; }

        //Внешние ключи
        public Guid TypeAnimalId { get; }

        public Guid AnimalStatusId { get; }

        // Навигационные свойства
        public TypeAnimal TypeAnimal { get; private set; }
        public AnimalStatus AnimalStatus { get; private set; }

        public static (Animal Animal, string Error) Create(
            Guid id, 
            string name, 
            string gender, 
            int age, 
            string description, 
            string photo,
            Guid typeAnimalId, 
            Guid animalStatusId)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = "Name can not be empty or longer then 250 symbols";
            }

            // Проверка обязательных внешних ключей
            if (typeAnimalId == Guid.Empty)
                error += string.IsNullOrEmpty(error) ? "Type is required" : "\nType is required";

            if (animalStatusId == Guid.Empty)
                error += string.IsNullOrEmpty(error) ? "Status is required" : "\nStatus is required";

            var animal = new Animal(id, name, gender, age, description, photo,
            typeAnimalId, animalStatusId);

            return (animal, error);
        }
    }
}