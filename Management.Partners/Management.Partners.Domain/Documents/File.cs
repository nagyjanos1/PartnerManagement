using Management.Partners.Domain.Base;

namespace Management.Partners.Domain.Documents;

public record File : BaseModel
{
    public static File None => new()
    {
        Name = string.Empty,
        Description = string.Empty,
        UploadedAt = DateTime.MinValue,
        StorageId = string.Empty,
    };

    public string Name { get; init; }

    public string Description { get; init; }

    public DateTime UploadedAt { get; init; }

    public string StorageId { get; init; }
}
