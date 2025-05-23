namespace AnimalShelter.Contracts.ContractsResponses
{
    public record AdoptionApplicationsResponse(
        Guid Id,
        DateOnly ApplicationDate,
        string Comment,
        Guid UserId,
        Guid AnimalId,
        Guid StatusAdoptionId
    );
}