using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Commands;

public record UpdateAddressCommand : IRequest<Address>
{
    public Guid Id { get; set; }

    public string Name { get; init; }

    public string CountryCode { get; init; }

    public string ZipCode { get; init; }

    public string City { get; init; }

    public string AddressValue { get; init; }

    public string PartnerId { get; init; }

    internal Address MapToModel()
    {
        return new Address
        {
            Id = Id,
            Name = Name,
            CountryCode = CountryCode,
            ZipCode = ZipCode,
            City = City,
            AddressValue = AddressValue,
            PartnerId = PartnerId
        };
    }
}
