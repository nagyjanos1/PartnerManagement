using Management.Partners.Application.Partners.Dtos;
using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Partners.Commands;

public record AddAddressCommand : IRequest<AddressDto>
{
    public string Name { get; init; }

    public string CountryCode { get; init; }

    public string ZipCode { get; init; }

    public string City { get; init; }

    public string AddressValue { get; init; }

    public string PartnerId { get; init; }

    internal Address MapToDomain()
    {
        return new Address
        {
            Id = Guid.NewGuid(),
            Name = Name,
            CountryCode = CountryCode,
            ZipCode = ZipCode,
            City = City,
            AddressValue = AddressValue,
        };
    }
}
