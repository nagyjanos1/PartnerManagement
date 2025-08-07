namespace Management.Partners.Application.Partners.Dtos;

public record AddressDto
{
    public static AddressDto None => new()
    {
        Id = Guid.Empty,
        Name = string.Empty,
        CountryCode = string.Empty,
        ZipCode = string.Empty,
        City = string.Empty,
        AddressValue = string.Empty,
        IsHeadquarter = false
    };

    public Guid Id { get; init; }

    public string Name { get; init; }

    public string CountryCode { get; init; }

    public string ZipCode { get; init; }

    public string City { get; init; }

    public string AddressValue { get; init; }

    public bool IsHeadquarter { get; init; }
}
