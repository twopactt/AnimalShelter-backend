namespace AnimalShelter.Contracts.ContractsRequests
{
    public record TemporaryAccommodationsRequest(
        DateOnly DateAnimalCapture,
        DateOnly DateAnimalReturn,
        Guid UserId,
        Guid AnimalId,
        Guid StatusTemporaryAccommodationId
    );
}