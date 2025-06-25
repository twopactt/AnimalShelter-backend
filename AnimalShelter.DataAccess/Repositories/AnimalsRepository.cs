using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.DataAccess.Repositories
{
    public class AnimalsRepository : IAnimalsRepository
    {
        private readonly AnimalShelterDbContext _context;

        public AnimalsRepository(AnimalShelterDbContext context)
        {
            _context = context;
        }

        public async Task<List<Animal>> Get()
        {
            var animalEntities = await _context.Animal
                .AsNoTracking()
                .ToListAsync();

            var animals = animalEntities
                .Select(b => Animal.Create(b.Id, b.Name, b.Gender, b.Age, b.Description, b.Photo, b.TypeAnimalId, b.AnimalStatusId).Animal)
                .ToList();

            return animals;
        }

        public async Task<Animal?> GetById(Guid id)
        {
            var animalEntity = await _context.Animal
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (animalEntity == null)
                return null;

            return Animal.Create(
                animalEntity.Id,
                animalEntity.Name,
                animalEntity.Gender,
                animalEntity.Age,
                animalEntity.Description,
                animalEntity.Photo,
                animalEntity.TypeAnimalId,
                animalEntity.AnimalStatusId).Animal;
        }

        public async Task<Guid> Create(Animal animal)
        {
            var animalEntity = new AnimalEntity
            {
                Id = animal.Id,
                Name = animal.Name,
                Gender = animal.Gender,
                Age = animal.Age,
                Description = animal.Description,
                Photo = animal.Photo,
                TypeAnimalId = animal.TypeAnimalId,
                AnimalStatusId = animal.AnimalStatusId
            };

            await _context.Animal.AddAsync(animalEntity);
            await _context.SaveChangesAsync();

            return animalEntity.Id;
        }

        public async Task<Guid> Update(
            Guid id,
            string name,
            string gender,
            int age,
            string description,
            string photo,
            Guid typeAnimalId,
            Guid animalStatusId)
        {
            await _context.Animal
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => name)
                    .SetProperty(b => b.Gender, b => gender)
                    .SetProperty(b => b.Age, b => age)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Photo, b => photo)
                    .SetProperty(b => b.TypeAnimalId, b => typeAnimalId)
                    .SetProperty(b => b.AnimalStatusId, b => animalStatusId));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            var animal = await _context.Animal.FirstOrDefaultAsync(a => a.Id == id);
            if (animal == null)
            {
                return id;
            }

            if (!string.IsNullOrEmpty(animal.Photo))
            {
                using var httpClient = new HttpClient();
                try
                {
                    var response = await httpClient.DeleteAsync($"http://localhost:5251/api/upload/delete-photo?photoPath={animal.Photo}");
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Failed to delete photo: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error calling delete photo API: {ex.Message}");
                }
            }

            await _context.Animal
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}