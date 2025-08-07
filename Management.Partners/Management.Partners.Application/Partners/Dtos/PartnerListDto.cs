namespace Management.Partners.Application.Partners.Dtos;

public record PartnerListDto
{
    public static PartnerListDto None => new()
    {
        Id = Guid.Empty,
        Name = string.Empty,
        Email = string.Empty,
        Phone = string.Empty
    };

    public Guid Id { get; init; }

    public string Name { get; init; }

    public string Email { get; init; }

    public string Phone { get; init; }
}
