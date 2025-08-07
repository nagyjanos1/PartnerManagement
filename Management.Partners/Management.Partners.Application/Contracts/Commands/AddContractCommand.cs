using Management.Partners.Application.Contracts.Dtos;
using Management.Partners.Domain.Contracts;
using MediatR;

namespace Management.Partners.Application.Contracts.Commands;

public record AddContractCommand : IRequest<ContractDto>
{
    public string Subject { get; init; }
    public string Description { get; init; }
    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
    public decimal NetValue { get; init; }
    public decimal VatValue { get; init; }
    public string Currency { get; init; }

    internal Contract MapToDomain()
    {
        var contract = Contract.Create(Subject, StartDate, EndDate);
        
        if (!string.IsNullOrWhiteSpace(Description))
        {
            contract = contract.WithDescription(Description);
        }

        if (NetValue > 0 && !string.IsNullOrWhiteSpace(Currency))
        {
            contract = contract.AddNetValue(NetValue, VatValue, Currency);
        }

        return contract;
    }
}