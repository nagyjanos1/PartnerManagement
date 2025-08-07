using Management.Partners.Application.Contracts.Dtos;
using Management.Partners.Domain.Contracts;
using MediatR;

namespace Management.Partners.Application.Contracts.Commands;

public record UpdateContractCommand : IRequest<ContractDto>
{
    public Guid Id { get; init; }
    public string Subject { get; init; }
    public string Description { get; init; }
    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
    public decimal NetValue { get; init; }
    public decimal VatValue { get; init; }
    public string Currency { get; init; }
    public ContractStatus Status { get; init; }

    internal Contract MapToDomain()
    {
        var contract = Contract.Create(Subject, StartDate, EndDate)
            with
        {
            Id = Id,
            Description = Description,
            Status = Status
        };

        if (NetValue > 0 && !string.IsNullOrWhiteSpace(Currency))
        {
            contract = contract.AddNetValue(NetValue, VatValue, Currency);
        }

        return contract;
    }
}