namespace AnimalShelter.Contracts
{
    public record AnimalsResponse(
        Guid Id,
        string Name,
        string Gender,
        int Age,
        string Description,
        string Photo,
        Guid TypeAnimalId, 
        Guid AnimalStatusId
    );
}