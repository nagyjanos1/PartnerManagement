using Management.Partners.Domain.Base;

namespace Management.Partners.Domain.Partners;

public record User : BaseModel
{
    public string Name { get; init; }

    public string Email { get; init; }

    public string Position { get; init; }

    public string Division { get; init; }
}