using Management.Partners.Domain.Base;

namespace Management.Partners.Domain.Contracts;

public record ContractHistory : BaseModel
{
    public static ContractHistory None => new() 
    { 
        FieldName = string.Empty,
        OldValue = string.Empty,
        NewValue = string.Empty,
        CreatedAt = DateTime.MinValue 
    };

    public required string FieldName { get; init; }

    public string OldValue { get; init; }

    public string NewValue { get; init; }

    public required DateTime CreatedAt { get; init; }

    private ContractHistory() { }

    public static ContractHistory Create(string fieldName, string newValue, string oldValue = null)
    {
        return new ContractHistory
        {
            FieldName = fieldName,
            NewValue = newValue,
            OldValue = oldValue,
            CreatedAt = DateTime.UtcNow
        };
    }
}
