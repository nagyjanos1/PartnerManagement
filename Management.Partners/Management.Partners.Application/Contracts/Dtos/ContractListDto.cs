using Management.Partners.Domain.Contracts;

namespace Management.Partners.Application.Contracts.Dtos;

public record ContractListDto
{
    public static ContractListDto None => new()
    {
        Id = Guid.Empty,
        Subject = string.Empty,
        Status = ContractStatus.None,
        StartDate = DateOnly.MinValue,
        EndDate = DateOnly.MinValue,
        GrossValue = 0,
        Currency = string.Empty
    };

    public Guid Id { get; init; }
    
    public string Subject { get; init; }
    
    public ContractStatus Status { get; init; }
    
    public DateOnly StartDate { get; init; }
    
    public DateOnly EndDate { get; init; }
    
    public decimal GrossValue { get; init; }
    
    public string Currency { get; init; }
}