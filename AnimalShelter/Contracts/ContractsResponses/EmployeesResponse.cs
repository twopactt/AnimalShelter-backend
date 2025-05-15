namespace AnimalShelter.Contracts.ContractsResponses
{
    public record EmployeesResponse(
        Guid Id,
        bool IsAdmin,
        Guid UserId
    );
}