using Management.Partners.Domain.Base;

namespace Management.Partners.Domain.Partners;

public record Address : BaseModel, IValueObject
{
    public static Address None => new()
    {
        Name = string.Empty,
        CountryCode = string.Empty,
        ZipCode = string.Empty,
        City = string.Empty,
        AddressValue = string.Empty,
        PartnerId = string.Empty,
        IsHeadquarter = false
    };

    public string Name { get; init; }

    public string CountryCode { get; init; }

    public string ZipCode { get; init; }

    public string City { get; init; }

    public string AddressValue { get; init; }

    public string PartnerId { get; init; }

    public bool IsHeadquarter { get; init; }
}
