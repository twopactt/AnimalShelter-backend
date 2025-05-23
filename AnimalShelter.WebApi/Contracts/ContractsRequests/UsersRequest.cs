namespace AnimalShelter.Contracts.ContractsRequests
{
    public record UsersRequest(
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