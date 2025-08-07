using System.ComponentModel.DataAnnotations;
using Management.Partners.Application.Contracts.Commands;
using Management.Partners.Domain.Contracts;

namespace Management.Partners.WebApi.Requests.Contract;

public record UpdateContractRequest
{
    [Required]
    public Guid Id { get; init; }

    [Required]
    [MaxLength(500)]
    public string Subject { get; init; }

    [MaxLength(2000)]
    public string Description { get; init; }

    [Required]
    public DateOnly StartDate { get; init; }

    public DateOnly EndDate { get; init; }

    [Range(0, double.MaxValue)]
    public decimal NetValue { get; init; }

    [Range(0, 100)]
    public decimal VatValue { get; init; }

    [MaxLength(10)]
    public string Currency { get; init; }

    public ContractStatus Status { get; init; }

    internal UpdateContractCommand GetCommand()
    {
        return new UpdateContractCommand
        {
            Id = Id,
            Subject = Subject,
            Description = Description,
            StartDate = StartDate,
            EndDate = EndDate,
            NetValue = NetValue,
            VatValue = VatValue,
            Currency = Currency,
            Status = Status
        };
    }
}