using MediatR;

namespace Management.Partners.Application.Contracts.Commands;

public record DeleteContractCommand : IRequest<Unit>
{
    public Guid Id { get; init; }
}