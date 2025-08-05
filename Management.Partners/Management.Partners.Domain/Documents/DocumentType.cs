using Management.Partners.Domain.Base;

namespace Management.Partners.Domain.Documents;

public record DocumentType : BaseModel
{
    public static DocumentType None => new() { Name = string.Empty, Description = string.Empty };

    public string Name { get; init; }

    public string Description { get; init; }
}
