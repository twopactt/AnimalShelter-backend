using AnimalShelter.Contracts.ContractsResponses;

namespace AnimalShelter.Contracts.ContractsResponses
{
    public record AuthsResponse(
        string Token,
        UsersResponse User
    );
}