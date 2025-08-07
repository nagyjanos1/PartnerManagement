using Management.Partners.Domain.Contracts;

namespace Management.Partners.Application.Contracts.Dtos;

public record ContractDto
{
    public static ContractDto None => new()
    {
        Id = Guid.Empty,
        Subject = string.Empty,
        Description = string.Empty,
        CreatedAt = DateTime.MinValue,
        LastUpdatedAt = null,
        Status = ContractStatus.None,
        StartDate = DateOnly.MinValue,
        EndDate = DateOnly.MinValue,
        GrossValue = 0,
        NetValue = 0,
        VatValue = 0,
        Currency = string.Empty
    };

    public Guid Id { get; init; }
    
    public string Subject { get; init; }
    
    public string Description { get; init; }
    
    public DateTime CreatedAt { get; init; }
    
    public DateTime? LastUpdatedAt { get; init; }
    
    public ContractStatus Status { get; init; }
    
    public DateOnly StartDate { get; init; }
    
    public DateOnly EndDate { get; init; }
    
    public decimal GrossValue { get; init; }
    
    public decimal NetValue { get; init; }
    
    public decimal VatValue { get; init; }
    
    public string Currency { get; init; }
}