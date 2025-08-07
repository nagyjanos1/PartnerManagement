using MediatR;

namespace Management.Partners.Application.Partners.Commands;

public record DeleteAddressCommand : IRequest<Unit>
{
    public required Guid Id { get; init; }
}
