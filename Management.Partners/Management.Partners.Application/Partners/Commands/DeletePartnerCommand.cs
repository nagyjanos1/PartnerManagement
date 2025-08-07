using MediatR;

namespace Management.Partners.Application.Partners.Commands;

public record DeletePartnerCommand : IRequest<Unit>
{
    public required Guid Id { get; init; }
}
