using Management.Partners.Domain.Base;

namespace Management.Partners.Domain.Partners;

public sealed record Partner : BaseModel, IAggregateRoot
{
    public string Name { get; init; }

    public string Email { get; init; }

    public string Phone { get; init; }

    public string Description { get; init; }

    public string TaxNumber { get; init; }

    public IReadOnlyCollection<Address> Addresses { get; init; }

    public IReadOnlyCollection<Contact> Contacts { get; init; }

    public static Partner None => new()
    {
        Name = string.Empty,
        Phone = string.Empty,
        Email = string.Empty,
        Description = string.Empty,
        Addresses = null,
    };

    public Partner()
    {
        Addresses = [];
    }

    public Partner AddAddress(Address address)
    {
        ArgumentNullException.ThrowIfNull(address);

        return this with
        {
            Addresses = [.. Addresses, address]
        };
    }

    public Partner RemoveAddress(Address address)
    {
        ArgumentNullException.ThrowIfNull(address);

        return this with
        {
            Addresses = [.. Addresses.Where(a => a.Id != address.Id)]
        };
    }
}
