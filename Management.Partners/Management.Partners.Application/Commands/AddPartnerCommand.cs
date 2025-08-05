using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Commands;

public record AddPartnerCommand : IRequest<Partner>
{
    public string Name { get; init; }

    public string Email { get; init; }

    public string Phone { get; init; }

    public string Description { get; init; }

    internal Partner MapToModel()
    {
        return new Partner
        {
            Name = Name,
            Email = Email,
            Phone = Phone,
            Description = Description
        };
    }
}
