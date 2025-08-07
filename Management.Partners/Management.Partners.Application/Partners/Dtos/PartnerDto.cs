namespace Management.Partners.Application.Partners.Dtos;

public record PartnerDto
{
    public static PartnerDto None => new()
    {
        Id = Guid.Empty,
        Name = string.Empty,
        Email = string.Empty,
        Phone = string.Empty,
        Description = string.Empty,
        TaxNumber = string.Empty,
        Addresses = []
    };

    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public string Email { get; init; }
    
    public string Phone { get; init; }
    
    public string Description { get; init; }
    
    public string TaxNumber { get; init; }
    
    public IReadOnlyCollection<AddressDto> Addresses { get; init; } = [];
}