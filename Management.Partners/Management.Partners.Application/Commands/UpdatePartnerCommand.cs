using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Commands;

public record UpdatePartnerCommand : IRequest<Partner>
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public string Email { get; init; }

    public string Phone { get; init; }

    public string Description { get; init; }        

    internal Partner MapToModel()
    {
        return new Partner
        {
            Id = Id,
            Name = Name,
            Email = Email,
            Phone = Phone,
            Description = Description
        };
    }
}
