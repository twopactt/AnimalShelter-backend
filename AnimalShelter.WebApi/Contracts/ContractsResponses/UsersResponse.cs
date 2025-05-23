namespace AnimalShelter.Contracts.ContractsResponses
{
    public record UsersResponse(
        Guid Id,
        string Surname,
        string Name,
        string Patronymic,
        DateOnly DateOfBirth,
        string Phone,
        string Email,
        string Login,
        string Password,
        Guid RoleId
    );
}