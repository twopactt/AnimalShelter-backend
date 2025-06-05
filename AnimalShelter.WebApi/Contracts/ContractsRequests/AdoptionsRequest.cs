namespace AnimalShelter.Contracts.ContractsRequests
{
    public record AdoptionsRequest(
        DateOnly ApplicationDate,
        Guid UserId,
        Guid AnimalId
    );
}