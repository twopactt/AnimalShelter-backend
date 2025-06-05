namespace AnimalShelter.Contracts.ContractsResponses
{
    public record AdoptionsResponse(
        Guid Id,
        DateOnly ApplicationDate,
        Guid UserId,
        Guid AnimalId
    );
}