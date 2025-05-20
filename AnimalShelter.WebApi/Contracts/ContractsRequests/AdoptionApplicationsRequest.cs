namespace AnimalShelter.Contracts.ContractsRequests
{
    public record AdoptionApplicationsRequest(
        DateOnly ApplicationDate,
        string Comment,
        Guid UserId,
        Guid AnimalId,
        Guid StatusAdoptionId
    );
}