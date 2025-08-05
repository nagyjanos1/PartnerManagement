using Management.Partners.Domain.Base;

namespace Management.Partners.Domain.Documents;

public record Document : BaseModel
{
    public static Document None => new()
    {
        Name = string.Empty,
        DocumentType = DocumentType.None,
        Description = string.Empty,
        Status = DocumentStatus.None,
        File = File.None,
    };

    public required string Name { get; init; }

    public string Description { get; init; }

    public required DocumentType DocumentType { get; init; }

    public DocumentStatus Status { get; init; }

    public File File { get; init; }

    public Document AddFile(File file)
    {
        return this with { File = file };
    }

    public Document SetDocumentStatus(DocumentStatus documentStatus)
    {
        return this with { Status = documentStatus };
    }

    public Document AddDescription(string description)
    {
        return this with { Description = description };
    }
}
