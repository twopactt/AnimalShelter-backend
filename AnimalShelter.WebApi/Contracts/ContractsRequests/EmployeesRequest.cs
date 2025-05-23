namespace AnimalShelter.Contracts.ContractsRequests
{
    public record EmployeesRequest(
        Guid Id,
        bool IsAdmin,
        Guid UserId
    );
}