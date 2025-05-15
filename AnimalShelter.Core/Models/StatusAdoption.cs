namespace AnimalShelter.Core.Models
{
    public class StatusAdoption
    {
        public const int MAX_NAME_LENGTH = 250;
        private StatusAdoption(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }

        public static (StatusAdoption StatusAdoption, string Error) Create(Guid id, string name)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = "Name can not be empty or longer then 250 symbols";
            }

            var statusAdoption = new StatusAdoption(id, name);

            return (statusAdoption, error);
        }
    }
}