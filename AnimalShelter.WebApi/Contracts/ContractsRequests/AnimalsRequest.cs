namespace AnimalShelter.Contracts.ContractsRequests
{
    public record AnimalsRequest(
        string Name,
        string Gender,
        int Age,
        string Description,
        string Photo,
        Guid TypeAnimalId,
        Guid AnimalStatusId
    );
}