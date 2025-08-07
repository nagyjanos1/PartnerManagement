using Management.Partners.Application.Partners.Dtos;
using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Partners.Commands;

public record AddPartnerCommand : IRequest<PartnerDto>
{
    public string Name { get; init; }

    public string Email { get; init; }

    public string Phone { get; init; }

    public string Description { get; init; }

    public string TaxNumber { get; init; }

    internal Partner MapToDomain()
    {
        return new Partner
        {
            Id = Guid.NewGuid(),
            Name = Name,
            Email = Email,
            Phone = Phone,
            Description = Description,
            TaxNumber = TaxNumber
        };
    }
}
