namespace AnimalShelter.Core.Models
{
    public class TypeAnimal
    {
        public const int MAX_NAME_LENGTH = 250;
        private TypeAnimal(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }

        public static (TypeAnimal TypeAnimal, string Error) Create(Guid id, string name)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = "Name can not be empty or longer then 250 symbols";
            }

            var typeAnimal = new TypeAnimal(id, name);

            return (typeAnimal, error);
        }
    }
}