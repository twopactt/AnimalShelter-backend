namespace AnimalShelter.Contracts.ContractsResponses
{
    public record TemporaryAccommodationsResponse(
        Guid Id,
        DateOnly DateAnimalCapture,
        DateOnly DateAnimalReturn,
        Guid UserId,
        Guid AnimalId
    );
}