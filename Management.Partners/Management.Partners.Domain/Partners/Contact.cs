using Management.Partners.Domain.Base;

namespace Management.Partners.Domain.Partners;

public sealed record Contact : BaseModel, IValueObject
{
    public string Name { get; init; }

    public string Email { get; init; }

    public string Phone { get; init; }

    public string Description { get; init; }

    public bool IsMain { get; init; }
}
